using FluentValidation;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace UniversityHelper.FeedbackService.Validation.Feedback;

public class FindFeedbacksRequestValidator : AbstractValidator<FindFeedbacksRequest>, IFindFeedbacksRequestValidator
{
    public FindFeedbacksRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0).WithMessage("Page number must be greater than 0.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("Page size must be greater than 0.")
            .LessThanOrEqualTo(100).WithMessage("Page size cannot exceed 100.");

        RuleFor(x => x.FeedbackStatus)
            .IsInEnum().When(x => x.FeedbackStatus.HasValue).WithMessage("Invalid feedback status.");

        RuleFor(x => x.FeedbackType)
            .IsInEnum().When(x => x.FeedbackType.HasValue).WithMessage("Invalid feedback type.");
    }
}