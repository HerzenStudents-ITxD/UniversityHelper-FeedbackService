using FluentValidation;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace UniversityHelper.FeedbackService.Validation.Feedback;

public class EditFeedbackStatusValidator : AbstractValidator<EditFeedbackStatusesRequest>, IEditFeedbackStatusValidator
{
public EditFeedbackStatusValidator(IFeedbackRepository repository)
{
  CascadeMode = CascadeMode.Stop;

  RuleFor(f => f.FeedbackIds)
      .NotNull()
      .Must(f => f?.Count > 0)
      .WithMessage("Feedback IDs must be specified.");

  RuleFor(f => f.Status)
      .IsInEnum()
      .WithMessage("Incorrect feedback status.");

  RuleFor(r => r)
      .MustAsync(async (r, _) => !await repository.HaveSameStatusAsync(r.FeedbackIds, r.Status))
      .WithMessage("Some feedbacks already have the specified status.");
}
}