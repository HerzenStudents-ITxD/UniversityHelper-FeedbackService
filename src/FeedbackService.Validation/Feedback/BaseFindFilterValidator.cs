using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace UniversityHelper.FeedbackService.Validation.Feedback;

public class BaseFindFilterValidator : IBaseFindFilterValidator
{
    private readonly IValidator<object> _validator;

    public BaseFindFilterValidator(IValidator<object> validator)
    {
        _validator = validator;
    }

    public bool ValidateCustom(object filter, out List<string> errors)
    {
        if (filter == null)
        {
            errors = new List<string> { "Filter cannot be null." };
            return false;
        }

        var validationResult = _validator.Validate(filter);
        if (!validationResult.IsValid)
        {
            errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return false;
        }

        errors = new List<string>();
        return true;
    }
}