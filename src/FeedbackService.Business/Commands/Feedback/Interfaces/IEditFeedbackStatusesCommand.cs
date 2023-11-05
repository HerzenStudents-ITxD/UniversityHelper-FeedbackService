using HerzenHelper.FeedbackService.Models.Dto.Requests;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using System.Threading.Tasks;

namespace HerzenHelper.FeedbackService.Business.Commands.Feedback.Interfaces
{
  [AutoInject]
  public interface IEditFeedbackStatusesCommand
  {
    Task<OperationResultResponse<bool>> ExecuteAsync(EditFeedbackStatusesRequest request);
  }
}
