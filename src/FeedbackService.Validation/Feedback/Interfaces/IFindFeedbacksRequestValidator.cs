using FluentValidation;
using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Dto.Requests;

namespace UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

[AutoInject]
public interface IFindFeedbacksRequestValidator : IValidator<FindFeedbacksRequestValidator>
{
}