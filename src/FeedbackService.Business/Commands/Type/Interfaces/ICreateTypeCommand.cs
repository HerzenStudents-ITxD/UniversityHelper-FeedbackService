using UniversityHelper.Core.Attributes;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.FeedbackService.Models.Dto.Requests;

namespace UniversityHelper.FeedbackService.Business.Commands.Type.Interfaces;
[AutoInject]
public interface ICreateTypeCommand
{
    Task<OperationResultResponse<Guid>> ExecuteAsync(CreateTypeRequest request);
}