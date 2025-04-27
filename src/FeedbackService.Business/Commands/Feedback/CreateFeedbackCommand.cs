using FluentValidation.Results;
using UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Db.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Business.Commands.Feedback
{
  /// <summary>
  /// Command to create a new feedback.
  /// </summary>
  public class CreateFeedbackCommand : ICreateFeedbackCommand
  {
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly ICreateFeedbackValidator _validator;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IDbFeedbackMapper _feedbackMapper;
    private readonly IResponseCreator _responseCreator;
    private readonly ILogger<CreateFeedbackCommand> _logger;

    public CreateFeedbackCommand(
        IFeedbackRepository feedbackRepository,
        ICreateFeedbackValidator validator,
        IHttpContextAccessor httpContextAccessor,
        IDbFeedbackMapper feedbackMapper,
        IResponseCreator responseCreator,
        ILogger<CreateFeedbackCommand> logger)
    {
      _feedbackRepository = feedbackRepository;
      _validator = validator;
      _httpContextAccessor = httpContextAccessor;
      _feedbackMapper = feedbackMapper;
      _responseCreator = responseCreator;
      _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateFeedbackRequest request)
    {
      string remoteIp = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "Unknown";
      _logger.LogInformation($"Remote IP is {remoteIp}. User {request?.User?.FirstName}");

      ValidationResult validationResult = await _validator.ValidateAsync(request);
      if (!validationResult.IsValid)
      {
        return _responseCreator.CreateFailureResponse<Guid?>(
            HttpStatusCode.BadRequest,
            validationResult.Errors.Select(vf => vf.ErrorMessage).ToList());
      }

      DbFeedback dbFeedback = _feedbackMapper.Map(request);
      dbFeedback.SenderIp = remoteIp; // Set the sender IP

      OperationResultResponse<Guid?> response = new();
      response.Body = await _feedbackRepository.CreateAsync(dbFeedback);

      _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

      return response.Body is null
          ? _responseCreator.CreateFailureResponse<Guid?>(HttpStatusCode.BadRequest)
          : response;
    }
  }
}