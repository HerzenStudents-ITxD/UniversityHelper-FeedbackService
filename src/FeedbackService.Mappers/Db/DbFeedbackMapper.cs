using UniversityHelper.FeedbackService.Mappers.Db.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Enums;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using System;
using System.Linq;

namespace UniversityHelper.FeedbackService.Mappers.Db
{
  /// <summary>
  /// Maps a feedback creation request to a database entity.
  /// </summary>
  public class DbFeedbackMapper : IDbFeedbackMapper
  {
    private readonly IDbImageMapper _imageMapper;

    public DbFeedbackMapper(IDbImageMapper imageMapper)
    {
      _imageMapper = imageMapper;
    }

    /// <inheritdoc/>
    public DbFeedback? Map(CreateFeedbackRequest? request)
    {
      if (request == null)
      {
        return null;
      }

      Guid feedbackId = Guid.NewGuid();
      return new DbFeedback
      {
        Id = feedbackId,
        Type = (int)request.Type,
        Content = request.Content,
        Status = (int)FeedbackStatusType.New,
        SenderFullName = request.User is null ? string.Empty : $"{request.User.LastName} {request.User.FirstName} {request.User.MiddleName}".Trim(),
        SenderId = request.User?.Id ?? Guid.Empty,
        CreatedAtUtc = DateTime.UtcNow,
        SenderIp = string.Empty, // Will be set in CreateFeedbackCommand
        Images = request.FeedbackImages?
              .Select(fi => _imageMapper.Map(fi, feedbackId))
              .Where(img => img != null)
              .ToList() ?? new List<DbImage>()
      };
    }
  }
}