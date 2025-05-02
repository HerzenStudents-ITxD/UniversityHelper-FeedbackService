using UniversityHelper.Core.Attributes;
using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.FeedbackService.Business.Commands.Type.Interfaces;
[AutoInject]
public interface IHideTypeCommand
{
    Task<OperationResultResponse<bool>> ExecuteAsync(Guid typeId);
}