using UniversityHelper.FeedbackService.Mappers.Patch.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace UniversityHelper.FeedbackService.Mappers.Patch;

public class PatchDbFeedbackMapper : IPatchDbFeedbackMapper
{
public JsonPatchDocument<DbFeedback>? Map(JsonPatchDocument<EditFeedbackRequest>? request)
{
  if (request == null)
  {
    return null;
  }

  JsonPatchDocument<DbFeedback> dbFeedbackPatch = new();

  foreach (Operation<EditFeedbackRequest> item in request.Operations)
  {
    if (item.path.EndsWith(nameof(EditFeedbackRequest.Content)) ||
        item.path.EndsWith(nameof(EditFeedbackRequest.Type)) ||
        item.path.EndsWith(nameof(EditFeedbackRequest.Status)))
    {
      dbFeedbackPatch.Operations.Add(new Operation<DbFeedback>(item.op, item.path, item.from, item.value));
    }
  }

  return dbFeedbackPatch;
}
}