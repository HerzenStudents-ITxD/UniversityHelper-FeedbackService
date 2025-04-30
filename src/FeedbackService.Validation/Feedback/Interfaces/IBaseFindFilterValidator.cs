using System.Collections.Generic;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.FeedbackService.Validation.Feedback.Interfaces
{
    [AutoInject]
    public interface IBaseFindFilterValidator
    {
        bool ValidateCustom(object filter, out List<string> errors);
    }
}