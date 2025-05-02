using UniversityHelper.Core.Attributes;
using FluentValidation;
using UniversityHelper.FeedbackService.Models.Dto.Requests;

namespace UniversityHelper.FeedbackService.Validation.Type.Interfaces;

[AutoInject]
public interface IUpdateTypeValidator : IValidator<UpdateTypeRequest>
{
}