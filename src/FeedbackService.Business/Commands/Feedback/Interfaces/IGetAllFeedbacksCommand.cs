using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using UniversityHelper.FeedbackService.Models.Dto.Responses;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces;

[AutoInject]
public interface IGetAllFeedbacksCommand
{
    Task<OperationResultResponse<FeedbackResponse[]>> ExecuteAsync();
}