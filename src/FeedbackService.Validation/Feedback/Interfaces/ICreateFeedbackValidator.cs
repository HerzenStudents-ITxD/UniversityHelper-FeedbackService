using FluentValidation;
using HerzenHelper.FeedbackService.Models.Dto.Requests;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.FeedbackService.Validation.Feedback.Interfaces
{
  [AutoInject]
  public interface ICreateFeedbackValidator : IValidator<CreateFeedbackRequest>
  {
  }
}
