using System.Net;
using FluentValidation.Results;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.FeedbackService.Business.Commands.Type.Interfaces;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Validation.Type.Interfaces;
using UniversityHelper.Core.Helpers.Interfaces;

namespace UniversityHelper.FeedbackService.Business.Commands.Type;

public class UpdateTypeCommand : IUpdateTypeCommand
{
    private readonly ITypeRepository _typeRepository;
    private readonly IUpdateTypeValidator _validator;
    private readonly IAccessValidator _accessValidator;
    private readonly IResponseCreator _responseCreator;

    public UpdateTypeCommand(
        ITypeRepository typeRepository,
        IUpdateTypeValidator validator,
        IAccessValidator accessValidator,
        IResponseCreator responseCreator)
    {
        _typeRepository = typeRepository;
        _validator = validator;
        _accessValidator = accessValidator;
        _responseCreator = responseCreator;
    }

    public async Task<OperationResultResponse<bool>> ExecuteAsync(UpdateTypeRequest request)
    {
        if (!await _accessValidator.IsAdminAsync())
        {
            return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
        }

        ValidationResult validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return _responseCreator.CreateFailureResponse<bool>(
                HttpStatusCode.BadRequest,
                validationResult.Errors.Select(vf => vf.ErrorMessage).ToList());
        }

        var type = await _typeRepository.GetByIdAsync(request.Id);

        if (type == null)
        {
            return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.NotFound);
        }

        type.Type = request.Type;
        type.Name = request.Name;
        await _typeRepository.UpdateAsync(type);

        return new OperationResultResponse<bool>(body: true);
    }
}
