using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Mappers.Models.Interfaces
{
  /// <summary>
  /// Interface for mapping database feedback entities to feedback information models.
  /// </summary>
  [AutoInject]
  public interface IFeedbackInfoMapper
  {
    /// <summary>
    /// Maps a database feedback entity to a feedback information model.
    /// </summary>
    /// <param name="dbFeedback">The database feedback entity.</param>
    /// <param name="imagesCount">The number of images associated with the feedback.</param>
    /// <returns>The mapped feedback information model, or null if input is null.</returns>
    FeedbackInfo? Map(DbFeedback? dbFeedback, int imagesCount);
  }
}