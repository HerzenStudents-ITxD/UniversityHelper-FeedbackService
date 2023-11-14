using FluentValidation;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace UniversityHelper.FeedbackService.Validation.Feedback;

public class CreateFeedbackValidator : AbstractValidator<CreateFeedbackRequest>, ICreateFeedbackValidator
{
  public CreateFeedbackValidator()
  {
    RuleFor(f => f.Type)
      .IsInEnum();
  }
}
