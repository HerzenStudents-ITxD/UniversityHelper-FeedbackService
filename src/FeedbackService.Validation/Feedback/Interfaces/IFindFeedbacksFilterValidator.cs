using FluentValidation;
using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Dto.Requests.Filter;

namespace UniversityHelper.FeedbackService.Validation.Feedback.Interfaces
{
  /// <summary>
  /// Validator interface for FindFeedbacksFilter.
  /// </summary>
  [AutoInject]
  public interface IFindFeedbacksFilterValidator : IValidator<FindFeedbacksFilter>
  {
  }
}