using FluentValidation;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace UniversityHelper.FeedbackService.Validation.Feedback
{
  /// <summary>
  /// Validator for the CreateFeedbackRequest.
  /// </summary>
  public class CreateFeedbackValidator : AbstractValidator<CreateFeedbackRequest>, ICreateFeedbackValidator
  {
    public CreateFeedbackValidator()
    {
      RuleFor(f => f.Type)
          .IsInEnum()
          .WithMessage("Invalid feedback type.");

      RuleFor(f => f.Content)
          .NotEmpty()
          .WithMessage("Feedback content is required.")
          .MaximumLength(1000)
          .WithMessage("Feedback content is too long.");

      RuleFor(f => f.FeedbackImages)
          .NotNull()
          .WithMessage("Feedback images are required.");
    }
  }
}