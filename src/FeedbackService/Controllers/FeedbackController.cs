using UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Models.Dto.Requests.Filter;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UniversityHelper.FeedbackService.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class FeedbackController : ControllerBase
  {
    /// <summary>
    /// Retrieves a specific feedback by its ID.
    /// </summary>
    /// <param name="feedbackId">The ID of the feedback to retrieve.</param>
    /// <param name="command">The command to execute the retrieval.</param>
    /// <returns>An operation result containing the feedback details.</returns>
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

    /// <summary>
    /// Finds feedbacks based on the provided filter.
    /// </summary>
    /// <param name="filter">The filter criteria for finding feedbacks.</param>
    /// <param name="command">The command to execute the search.</param>
    /// <returns>A result containing a list of feedback information and total count.</returns>
    [HttpGet("find")]
    [ProducesResponseType(typeof(FindResultResponse<FeedbackInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<FindResultResponse<FeedbackInfo>> FindAsync(
        [FromQuery] FindFeedbacksFilter filter,
        [FromServices] IFindFeedbacksCommand command)
    {
      return await command.ExecuteAsync(filter);
    }

    /// <summary>
    /// Creates a new feedback.
    /// </summary>
    /// <param name="request">The request containing feedback details.</param>
    /// <param name="command">The command to execute the creation.</param>
    /// <returns>An operation result containing the ID of the created feedback.</returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(OperationResultResponse<Guid?>), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
        [FromBody] CreateFeedbackRequest request,
        [FromServices] ICreateFeedbackCommand command)
    {
      return await command.ExecuteAsync(request);
    }

    /// <summary>
    /// Updates the status of multiple feedbacks.
    /// </summary>
    /// <param name="request">The request containing feedback IDs and new status.</param>
    /// <param name="command">The command to execute the status update.</param>
    /// <returns>An operation result indicating success or failure.</returns>
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
}