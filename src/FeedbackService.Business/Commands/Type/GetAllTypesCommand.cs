using System.Linq;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.FeedbackService.Business.Commands.Type.Interfaces;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Responses.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Business.Commands.Type;

public class GetAllTypesCommand : IGetAllTypesCommand
{
    private readonly ITypeRepository _typeRepository;
    private readonly ITypeResponseMapper _responseMapper;

    public GetAllTypesCommand(
        ITypeRepository typeRepository,
        ITypeResponseMapper responseMapper)
    {
        _typeRepository = typeRepository;
        _responseMapper = responseMapper;
    }

    public async Task<OperationResultResponse<TypeResponse[]>> ExecuteAsync()
    {
        var types = await _typeRepository.GetAllAsync();
        var response = types.Select(t => _responseMapper.Map(t)).ToArray();
        return new OperationResultResponse<TypeResponse[]>(body: response);
    }
}