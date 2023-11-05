using FluentValidation;
using HerzenHelper.FeedbackService.Models.Dto.Requests;
using HerzenHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace HerzenHelper.FeedbackService.Validation.Feedback
{
  public class CreateFeedbackValidator : AbstractValidator<CreateFeedbackRequest>, ICreateFeedbackValidator
  {
    public CreateFeedbackValidator()
    {
      RuleFor(f => f.Type)
        .IsInEnum();
    }
  }
}
