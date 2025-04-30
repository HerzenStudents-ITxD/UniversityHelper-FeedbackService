using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests;

namespace UniversityHelper.FeedbackService.Mappers.Db.Interfaces
{
  /// <summary>
  /// Interface for mapping feedback creation requests to database entities.
  /// </summary>
  [AutoInject]
  public interface IDbFeedbackMapper
  {
    /// <summary>
    /// Maps a feedback creation request to a database feedback entity.
    /// </summary>
    /// <param name="request">The feedback creation request to map.</param>
    /// <returns>The mapped database feedback entity, or null if input is null.</returns>
    DbFeedback? Map(CreateFeedbackRequest? request);
  }
}