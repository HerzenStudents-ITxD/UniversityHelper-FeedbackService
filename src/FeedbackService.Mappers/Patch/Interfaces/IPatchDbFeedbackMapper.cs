using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.FeedbackService.Mappers.Patch.Interfaces
{
  /// <summary>
  /// Interface for mapping JSON patch documents to feedback database entities.
  /// </summary>
  [AutoInject]
  public interface IPatchDbFeedbackMapper
  {
    /// <summary>
    /// Maps a JSON patch document for feedback requests to a database entity patch.
    /// </summary>
    /// <param name="request">The JSON patch document for the feedback request.</param>
    /// <returns>A JSON patch document for the database feedback entity.</returns>
    JsonPatchDocument<DbFeedback> Map(JsonPatchDocument<EditFeedbackRequest> request);
  }
}