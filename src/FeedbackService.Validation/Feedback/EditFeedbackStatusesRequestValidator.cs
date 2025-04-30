using FluentValidation;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace UniversityHelper.FeedbackService.Validation.Feedback
{
    public class EditFeedbackStatusesRequestValidator : AbstractValidator<EditFeedbackStatusesRequest>, IEditFeedbackStatusesRequestValidator
    {
        public EditFeedbackStatusesRequestValidator()
        {
            RuleFor(x => x.FeedbackIds)
                .NotEmpty().WithMessage("Feedback IDs list cannot be empty.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid feedback status.");
        }
    }
}