using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces
{
  [AutoInject]
  public interface IEditFeedbackStatusesCommand
  {
    Task<OperationResultResponse<bool>> ExecuteAsync(EditFeedbackStatusesRequest request);
  }
}
