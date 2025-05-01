using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Data.Provider.MsSql.Ef;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.FeedbackService.Data.Provider;

namespace UniversityHelper.FeedbackService.Data;


public class FeedbackRepository : IFeedbackRepository
{
    private readonly IDataProvider _provider;

    public FeedbackRepository(IDataProvider provider)
    {
      _provider = provider;
    }


public async Task<Guid?> CreateAsync(DbFeedback dbFeedback)
{
  if (dbFeedback == null)
  {
    return null;
  }

  await _provider.Feedbacks.AddAsync(dbFeedback);
  await _provider.SaveAsync();
  return dbFeedback.Id;
}

    public async Task<(List<DbFeedback> feedbacks, int totalCount)> FindAsync(
                Guid? userId,
                FeedbackStatusType? status,
                FeedbackType? type,
                bool orderByDescending,
                int page,
                int pageSize,
                CancellationToken cancellationToken)
    {
        var query = _provider.Feedbacks
            .Include(f => f.Images)
            .AsQueryable();

        if (userId.HasValue)
        {
            query = query.Where(f => f.SenderId == userId.Value);
        }

        if (status.HasValue)
        {
            query = query.Where(f => (FeedbackStatusType)f.Status == status.Value);
        }

        if (type.HasValue)
        {
            query = query.Where(f => (FeedbackType)f.Type == type.Value);
        }

        if (orderByDescending)
        {
            query = query.OrderByDescending(f => f.CreatedAtUtc);
        }
        else
        {
            query = query.OrderBy(f => f.CreatedAtUtc);
        }

        var totalCount = await query.CountAsync(cancellationToken);
        var feedbacks = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (feedbacks, totalCount);
    }

    public async Task<DbFeedback?> GetAsync(Guid feedbackId)
{
  return await _provider.Feedbacks
      .Include(f => f.Images)
      .FirstOrDefaultAsync(f => f.Id == feedbackId);
}

public async Task<DbFeedback?> GetByIdAsync(Guid feedbackId)
{
  return await _provider.Feedbacks
      .Include(f => f.Images)
      .FirstOrDefaultAsync(f => f.Id == feedbackId);
}

public async Task<bool> HaveSameStatusAsync(List<Guid> feedbackIds, FeedbackStatusType status)
{
  if (feedbackIds == null || !feedbackIds.Any())
  {
    return false;
  }

  return await _provider.Feedbacks
      .Where(f => feedbackIds.Contains(f.Id))
      .AnyAsync(f => f.Status == (int)status);
}

public async Task<bool> EditStatusesAsync(List<Guid> feedbackIds, FeedbackStatusType status)
{
  if (feedbackIds == null || !feedbackIds.Any())
  {
    return false;
  }

  var feedbacks = await _provider.Feedbacks
      .Where(f => feedbackIds.Contains(f.Id))
      .ToListAsync();

  foreach (var feedback in feedbacks)
  {
    feedback.Status = (int)status;
  }

  await _provider.SaveAsync();
  return true;
}
}