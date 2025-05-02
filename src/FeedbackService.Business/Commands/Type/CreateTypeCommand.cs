using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Net;
using UniversityHelper.Core.Responses;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.FeedbackService.Business.Commands.Type.Interfaces;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Db.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Validation.Type.Interfaces;
using UniversityHelper.Core.Helpers.Interfaces;

namespace UniversityHelper.FeedbackService.Business.Commands.Type;

public class CreateTypeCommand : ICreateTypeCommand
{
    private readonly ITypeRepository _typeRepository;
    private readonly ICreateTypeValidator _validator;
    private readonly IDbTypeMapper _mapper;
    private readonly IAccessValidator _accessValidator;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IResponseCreator _responseCreator;

    public CreateTypeCommand(
        ITypeRepository typeRepository,
        ICreateTypeValidator validator,
        IDbTypeMapper mapper,
        IAccessValidator accessValidator,
        IHttpContextAccessor httpContextAccessor,
        IResponseCreator responseCreator)
    {
        _typeRepository = typeRepository;
        _validator = validator;
        _mapper = mapper;
        _accessValidator = accessValidator;
        _httpContextAccessor = httpContextAccessor;
        _responseCreator = responseCreator;
    }

    public async Task<OperationResultResponse<Guid>> ExecuteAsync(CreateTypeRequest request)
    {
        if (!await _accessValidator.IsAdminAsync())
        {
            return _responseCreator.CreateFailureResponse<Guid>(HttpStatusCode.Forbidden);
        }

        ValidationResult validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return _responseCreator.CreateFailureResponse<Guid>(
                HttpStatusCode.BadRequest,
                validationResult.Errors.Select(vf => vf.ErrorMessage).ToList());
        }

        OperationResultResponse<Guid> response = new();

        var dbType = _mapper.Map(request);
        await _typeRepository.CreateAsync(dbType);

        _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
        response.Body = dbType.Id;

        return response;
    }
}
