using UniversityHelper.Core.Responses;
using UniversityHelper.FeedbackService.Core.Interfaces;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Responses.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.FeedbackService.Models.Dto.Responses;
using Microsoft.AspNetCore.Http;
using UniversityHelper.FeedbackService.Business.Commands.Feedback.Interfaces;

namespace UniversityHelper.FeedbackService.Business.Commands.Feedback;

public class FindFeedbacksCommand : IFindFeedbacksCommand
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IFeedbackImageRepository _imageRepository;
    private readonly IImageInfoMapper _imageInfoMapper;
    private readonly IFeedbackResponseMapper _responseMapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IResponseCreator _responseCreator;

    public FindFeedbacksCommand(
        IFeedbackRepository feedbackRepository,
        IFeedbackImageRepository imageRepository,
        IImageInfoMapper imageInfoMapper,
        IFeedbackResponseMapper responseMapper,
        IHttpContextAccessor httpContextAccessor,
        IResponseCreator responseCreator)
    {
        _feedbackRepository = feedbackRepository;
        _imageRepository = imageRepository;
        _imageInfoMapper = imageInfoMapper;
        _responseMapper = responseMapper;
        _httpContextAccessor = httpContextAccessor;
        _responseCreator = responseCreator;
    }

    public async Task<FindResultResponse<FeedbackResponse>> ExecuteAsync(FindFeedbacksRequest request, CancellationToken cancellationToken)
    {
        var userId = _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;
        Guid? userGuid = string.IsNullOrEmpty(userId) ? null : Guid.Parse(userId);

        var (feedbacks, totalCount) = await _feedbackRepository.FindAsync(
            userGuid,
            request.FeedbackStatus,
            request.FeedbackType,
            request.OrderByDescending,
            request.Page,
            request.PageSize,
            cancellationToken);

        var responses = new List<FeedbackResponse>();
        foreach (var feedback in feedbacks)
        {
            var images = await _imageRepository.GetImagesByFeedbackId(feedback.Id, cancellationToken);
            var imageInfos = images.Select(i => _imageInfoMapper.Map(i)).Where(i => i != null).ToList();
            responses.Add(_responseMapper.Map(feedback, imageInfos));
        }

        return _responseCreator.CreateSuccessFindResponse(responses, totalCount);
    }
}