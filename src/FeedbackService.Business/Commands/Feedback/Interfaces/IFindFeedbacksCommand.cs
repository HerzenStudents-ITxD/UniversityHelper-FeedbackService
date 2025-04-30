using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces;

[AutoInject]
public interface IFindFeedbacksCommand
{
    Task<FindResultResponse<FeedbackResponse>> ExecuteAsync(FindFeedbacksRequest request, CancellationToken cancellationToken);
}