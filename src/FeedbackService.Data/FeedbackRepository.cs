using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Data.Provider.MsSql.Ef;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Data
{
  /// <summary>
  /// Repository for managing feedback entities.
  /// </summary>
  public class FeedbackRepository : IFeedbackRepository
  {
    private readonly FeedbackServiceDbContext _context;

    public FeedbackRepository(FeedbackServiceDbContext context)
    {
      _context = context;
    }

    /// <inheritdoc/>
    public async Task<Guid?> CreateAsync(DbFeedback dbFeedback)
    {
      if (dbFeedback == null)
      {
        return null;
      }

      await _context.Feedbacks.AddAsync(dbFeedback);
      await _context.SaveChangesAsync();
      return dbFeedback.Id;
    }

    /// <inheritdoc/>
    public async Task<(List<(DbFeedback dbFeedback, int imagesCount)>?, int)> FindAsync(FindFeedbacksFilter filter)
    {
      if (filter == null)
      {
        return (null, 0);
      }

      IQueryable<DbFeedback> query = _context.Feedbacks
          .Include(f => f.Images);

      if (filter.FeedbackType.HasValue)
      {
        query = query.Where(f => f.Type == (int)filter.FeedbackType.Value);
      }

      if (filter.FeedbackStatus.HasValue)
      {
        query = query.Where(f => f.Status == (int)filter.FeedbackStatus.Value);
      }

      int totalCount = await query.CountAsync();

      var feedbacks = await query
          .OrderByDescending(f => f.CreatedAtUtc)
          .Skip(filter.SkipCount)
          .Take(filter.TakeCount)
          .Select(f => new
          {
            Feedback = f,
            ImagesCount = f.Images.Count
          })
          .ToListAsync();

      var result = feedbacks.Select(f => (f.Feedback, f.ImagesCount)).ToList();
      return (result, totalCount);
    }

    /// <inheritdoc/>
    public async Task<DbFeedback?> GetByIdAsync(Guid feedbackId)
    {
      return await _context.Feedbacks
          .Include(f => f.Images)
          .FirstOrDefaultAsync(f => f.Id == feedbackId);
    }

    /// <inheritdoc/>
    public async Task<bool> HaveSameStatusAsync(ICollection<Guid> feedbackIds, FeedbackStatusType status)
    {
      if (feedbackIds == null || !feedbackIds.Any())
      {
        return false;
      }

      return await _context.Feedbacks
          .Where(f => feedbackIds.Contains(f.Id))
          .AnyAsync(f => f.Status == (int)status);
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateStatusAsync(ICollection<Guid> feedbackIds, FeedbackStatusType status)
    {
      if (feedbackIds == null || !feedbackIds.Any())
      {
        return false;
      }

      var feedbacks = await _context.Feedbacks
          .Where(f => feedbackIds.Contains(f.Id))
          .ToListAsync();

      foreach (var feedback in feedbacks)
      {
        feedback.Status = (int)status;
      }

      await _context.SaveChangesAsync();
      return true;
    }
  }
}