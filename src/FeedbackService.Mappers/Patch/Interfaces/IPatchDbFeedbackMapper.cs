using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.FeedbackService.Mappers.Patch.Interfaces
{
  [AutoInject]
  public interface IPatchDbFeedbackMapper
  {
    JsonPatchDocument<DbFeedback>? Map(JsonPatchDocument<EditFeedbackRequest>? request);
  }
}