using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Responses;
using UniversityHelper.FeedbackService.Business.Commands.Type.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Controllers;

[Route("type")]
[ApiController]
public class TypeController : ControllerBase
{
    [HttpGet("all")]
    [ProducesResponseType(typeof(OperationResultResponse<TypeResponse[]>), StatusCodes.Status200OK)]
    public async Task<OperationResultResponse<TypeResponse[]>> GetAllAsync(
        [FromServices] IGetAllTypesCommand command)
    {
        return await command.ExecuteAsync();
    }

    [HttpPut("update")]
    [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<OperationResultResponse<bool>> UpdateAsync(
        [FromBody] UpdateTypeRequest request,
        [FromServices] IUpdateTypeCommand command)
    {
        return await command.ExecuteAsync(request);
    }

    [HttpPut("hide/{typeId}")]
    [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<OperationResultResponse<bool>> HideAsync(
        [FromRoute] Guid typeId,
        [FromServices] IHideTypeCommand command)
    {
        return await command.ExecuteAsync(typeId);
    }

    [HttpPut("show/{typeId}")]
    [ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<OperationResultResponse<bool>> ShowAsync(
        [FromRoute] Guid typeId,
        [FromServices] IShowTypeCommand command)
    {
        return await command.ExecuteAsync(typeId);
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(OperationResultResponse<Guid>), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<OperationResultResponse<Guid>> CreateAsync(
        [FromBody] CreateTypeRequest request,
        [FromServices] ICreateTypeCommand command)
    {
        return await command.ExecuteAsync(request);
    }
}