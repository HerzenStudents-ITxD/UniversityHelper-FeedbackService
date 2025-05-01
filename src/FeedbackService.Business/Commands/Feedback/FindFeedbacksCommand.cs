using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UniversityHelper.Core.Responses;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Responses.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Models.Dto.Responses;
using UniversityHelper.FeedbackService.Validation.Feedback.Interfaces;

namespace UniversityHelper.FeedbackService.Business.Commands.Feedback
{
    public class FindFeedbacksCommand : IFindFeedbacksCommand
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IFeedbackResponseMapper _responseMapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IResponseCreator _responseCreator;
        private readonly IFindFeedbacksRequestValidator _validator;

        public FindFeedbacksCommand(
            IFeedbackRepository feedbackRepository,
            IFeedbackResponseMapper responseMapper,
            IHttpContextAccessor httpContextAccessor,
            IResponseCreator responseCreator,
            IFindFeedbacksRequestValidator validator)
        {
            _feedbackRepository = feedbackRepository;
            _responseMapper = responseMapper;
            _httpContextAccessor = httpContextAccessor;
            _responseCreator = responseCreator;
            _validator = validator;
        }

        public async Task<FindResultResponse<FeedbackResponse>> ExecuteAsync(FindFeedbacksRequest request, CancellationToken cancellationToken)
        {
            FindResultResponse<FeedbackResponse> response = new();
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return _responseCreator.CreateFailureFindResponse<FeedbackResponse>(
                    System.Net.HttpStatusCode.BadRequest,
                    validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;
            Guid? userGuid = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId);

            var (feedbacks, totalCount) = await _feedbackRepository.FindAsync(
                userGuid,
                request.FeedbackStatus,
                request.FeedbackTypeIds,
                request.OrderByDescending,
                request.Page,
                request.PageSize,
                cancellationToken);
                        
            response.Body = new();
            response.Body.AddRange(feedbacks.Select(_responseMapper.Map).Where(x => x != null).ToList());

            response.TotalCount = totalCount;
            return response;
        }
    }
}