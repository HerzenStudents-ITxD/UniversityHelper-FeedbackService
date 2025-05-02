using UniversityHelper.Core.Attributes;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Business.Commands.Type.Interfaces;
[AutoInject]
public interface IGetAllTypesCommand
{
    Task<OperationResultResponse<TypeResponse[]>> ExecuteAsync();
}