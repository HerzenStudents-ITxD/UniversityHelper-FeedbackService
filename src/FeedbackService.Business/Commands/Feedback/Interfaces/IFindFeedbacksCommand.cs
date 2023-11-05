using HerzenHelper.FeedbackService.Models.Dto.Models;
using HerzenHelper.FeedbackService.Models.Dto.Requests.Filter;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using System.Threading.Tasks;

namespace HerzenHelper.FeedbackService.Business.Commands.Feedback.Interfaces
{
  [AutoInject]
  public interface IFindFeedbacksCommand
  {
    Task<FindResultResponse<FeedbackInfo>> ExecuteAsync(FindFeedbacksFilter filter);
  }
}
