using FluentValidation;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace UniversityHelper.FeedbackService.Validation.Feedback;

public class CreateFeedbackValidator : AbstractValidator<CreateFeedbackRequest>, ICreateFeedbackValidator
{
    public CreateFeedbackValidator()
    {
        RuleFor(f => f.TypeIds)
            .NotNull()
            .Must(ids => ids != null && ids.Any())
            .WithMessage("At least one feedback type ID is required.");

        RuleFor(f => f.Content)
            .NotEmpty()
            .WithMessage("Feedback content is required.")
            .MaximumLength(1000)
            .WithMessage("Feedback content is too long.");

        RuleFor(f => f.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(f => f.Status)
            .InclusiveBetween(0, 3)
            .WithMessage("Invalid status value.");
    }
}