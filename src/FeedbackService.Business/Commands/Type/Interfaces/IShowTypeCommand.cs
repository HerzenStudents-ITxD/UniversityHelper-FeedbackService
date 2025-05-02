using UniversityHelper.Core.Attributes;
using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.FeedbackService.Business.Commands.Type.Interfaces;
[AutoInject]
public interface IShowTypeCommand
{
    Task<OperationResultResponse<bool>> ExecuteAsync(Guid typeId);
}