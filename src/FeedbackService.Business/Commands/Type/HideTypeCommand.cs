using System.Net;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.FeedbackService.Business.Commands.Type.Interfaces;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.Core.Helpers.Interfaces;

namespace UniversityHelper.FeedbackService.Business.Commands.Type;

public class HideTypeCommand : IHideTypeCommand
{
    private readonly ITypeRepository _typeRepository;
    private readonly IAccessValidator _accessValidator;
    private readonly IResponseCreator _responseCreator;

    public HideTypeCommand(
        ITypeRepository typeRepository,
        IAccessValidator accessValidator,
        IResponseCreator responseCreator)
    {
        _typeRepository = typeRepository;
        _accessValidator = accessValidator;
        _responseCreator = responseCreator;
    }

    public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid typeId)
    {
        if (!await _accessValidator.IsAdminAsync())
        {
            return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
        }

        var type = await _typeRepository.GetByIdAsync(typeId);

        if (type == null)
        {
            return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.NotFound);
        }

        type.IsActive = false;
        await _typeRepository.UpdateAsync(type);

        return new OperationResultResponse<bool>(body: true);
    }
}
