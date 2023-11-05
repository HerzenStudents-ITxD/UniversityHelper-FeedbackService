using HerzenHelper.FeedbackService.Models.Dto.Requests;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using System;
using System.Threading.Tasks;

namespace HerzenHelper.FeedbackService.Business.Commands.Feedback.Interfaces
{
  [AutoInject]
  public interface ICreateFeedbackCommand
  {
    Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateFeedbackRequest request);
  }
}
