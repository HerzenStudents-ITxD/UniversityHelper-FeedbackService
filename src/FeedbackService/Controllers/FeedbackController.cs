using UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Models.Dto.Requests.Filter;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Controllers;

[Route("[controller]")]
[ApiController]
public class FeedbackController : ControllerBase
{
[HttpGet("get")]
[ProducesResponseType(typeof(OperationResultResponse<FeedbackResponse>), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public async Task<OperationResultResponse<FeedbackResponse>> GetAsync(
    [FromQuery] Guid feedbackId,
    [FromServices] IGetFeedbackCommand command)
{
  return await command.ExecuteAsync(feedbackId);
}

[HttpGet("find")]
[ProducesResponseType(typeof(FindResultResponse<FeedbackInfo>), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public async Task<FindResultResponse<FeedbackInfo>> FindAsync(
    [FromServices] IFindFeedbacksCommand command,
    [FromQuery] FindFeedbacksRequest request,
    [FromQuery] CancellationToken cancellationToken)
    {
  return await command.ExecuteAsync(filter, cancellationToken);
}

[HttpPost("create")]
[ProducesResponseType(typeof(OperationResultResponse<Guid?>), StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromBody] CreateFeedbackRequest request,
    [FromServices] ICreateFeedbackCommand command)
{
  return await command.ExecuteAsync(request);
}

[HttpPut("editstatus")]
[ProducesResponseType(typeof(OperationResultResponse<bool>), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public async Task<OperationResultResponse<bool>> EditStatusAsync(
    [FromBody] EditFeedbackStatusesRequest request,
    [FromServices] IEditFeedbackStatusesCommand command)
{
  return await command.ExecuteAsync(request);
}
}