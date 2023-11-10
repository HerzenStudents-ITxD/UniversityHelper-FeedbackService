using UniversityHelper.FeedbackService.Models.Dto.Models;
using UniversityHelper.FeedbackService.Models.Dto.Requests.Filter;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces
{
  [AutoInject]
  public interface IFindFeedbacksCommand
  {
    Task<FindResultResponse<FeedbackInfo>> ExecuteAsync(FindFeedbacksFilter filter);
  }
}
