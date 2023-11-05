using FluentValidation;
using HerzenHelper.FeedbackService.Data.Interfaces;
using HerzenHelper.FeedbackService.Models.Dto.Requests;
using HerzenHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace HerzenHelper.FeedbackService.Validation.Feedback
{
  public class EditFeedbackStatusValidator : AbstractValidator<EditFeedbackStatusesRequest>, IEditFeedbackStatusValidator
  {
    public EditFeedbackStatusValidator(IFeedbackRepository repository)
    {
      CascadeMode = CascadeMode.Stop;

      RuleFor(f => f.FeedbackIds)
        .Must(f => f.Count > 0)
        .WithMessage("Feedback ids must be specified.");

      RuleFor(f => f.Status)
        .IsInEnum()
        .WithMessage("Incorrect feedback status.");

      RuleFor(r => r)
        .MustAsync(async (r, _) => !await repository.HaveSameStatusAsync(r.FeedbackIds, r.Status))
        .WithMessage("Some of feedbacks already has specified status.");
    }
  }
}
