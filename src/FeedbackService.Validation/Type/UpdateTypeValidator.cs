using FluentValidation;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Validation.Type.Interfaces;

namespace UniversityHelper.FeedbackService.Validation.Type;

public class UpdateTypeValidator : AbstractValidator<UpdateTypeRequest>, IUpdateTypeValidator
{
    public UpdateTypeValidator()
    {
        RuleFor(t => t.Id)
            .NotEmpty()
            .WithMessage("Type ID is required.");

        RuleFor(t => t.Type)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Type must be non-negative.");

        RuleFor(t => t.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Must(BeValidJson)
            .WithMessage("Name must be a valid JSON string with translations.");
    }

    private bool BeValidJson(string name)
    {
        try
        {
            System.Text.Json.JsonDocument.Parse(name);
            return true;
        }
        catch
        {
            return false;
        }
    }
}