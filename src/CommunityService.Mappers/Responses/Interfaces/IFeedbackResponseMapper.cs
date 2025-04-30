using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System.Collections.Generic;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Mappers.Responses.Interfaces
{
    /// <summary>
    /// Interface for mapping feedback information to a feedback response.
    /// </summary>
    [AutoInject]
  public interface IFeedbackResponseMapper
  {
    /// <summary>
    /// Maps feedback information and images to a feedback response.
    /// </summary>
    /// <param name="feedbackInfo">The feedback information to map.</param>
    /// <param name="images">The list of images to include.</param>
    /// <returns>The mapped feedback response, or null if input is null.</returns>
    FeedbackResponse? Map(FeedbackInfo? feedbackInfo, IEnumerable<ImageInfo>? images);

    /// <summary>
    /// Maps a database feedback entity to a feedback response.
    /// </summary>
    /// <param name="dbFeedback">The database feedback entity to map.</param>
    /// <returns>The mapped feedback response, or null if input is null.</returns>
    FeedbackResponse? Map(DbFeedback? dbFeedback);
  }
}