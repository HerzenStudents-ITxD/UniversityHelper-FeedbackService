using UniversityHelper.FeedbackService.Models.Dto;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using System;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces
{
  [AutoInject]
  public interface IGetFeedbackCommand
  {
    Task<OperationResultResponse<FeedbackResponse>> ExecuteAsync(Guid feedbackId);
  }
}
