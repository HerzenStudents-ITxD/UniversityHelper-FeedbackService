using FluentValidation;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

[AutoInject]
public interface IEditFeedbackStatusValidator : IValidator<EditFeedbackStatusesRequest>
{
}
