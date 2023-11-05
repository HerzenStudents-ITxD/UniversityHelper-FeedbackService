using HerzenHelper.FeedbackService.Models.Dto;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using System;
using System.Threading.Tasks;

namespace HerzenHelper.FeedbackService.Business.Commands.Feedback.Interfaces
{
  [AutoInject]
  public interface IGetFeedbackCommand
  {
    Task<OperationResultResponse<FeedbackResponse>> ExecuteAsync(Guid feedbackId);
  }
}
