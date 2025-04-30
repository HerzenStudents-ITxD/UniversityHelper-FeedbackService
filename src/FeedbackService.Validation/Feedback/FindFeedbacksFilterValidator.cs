using FluentValidation;
using UniversityHelper.FeedbackService.Models.Dto.Requests.Filter;
using UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace UniversityHelper.FeedbackService.Validation.Feedback
{
  public class FindFeedbacksFilterValidator : AbstractValidator<FindFeedbacksFilter>, IFindFeedbacksFilterValidator
  {
    public FindFeedbacksFilterValidator()
    {
      RuleFor(f => f.SkipCount)
          .GreaterThanOrEqualTo(0)
          .WithMessage("Skip count must be non-negative.");

      RuleFor(f => f.TakeCount)
          .GreaterThan(0)
          .WithMessage("Take count must be positive.")
          .LessThanOrEqualTo(100)
          .WithMessage("Take count must not exceed 100.");

      When(f => f.FeedbackType.HasValue, () =>
          RuleFor(f => f.FeedbackType)
              .IsInEnum()
              .WithMessage("Invalid feedback type."));

      When(f => f.FeedbackStatus.HasValue, () =>
          RuleFor(f => f.FeedbackStatus)
              .IsInEnum()
              .WithMessage("Invalid feedback status."));
    }
  }
}