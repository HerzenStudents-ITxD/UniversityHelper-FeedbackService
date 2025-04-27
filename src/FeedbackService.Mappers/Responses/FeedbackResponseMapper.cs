using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Responses.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityHelper.FeedbackService.Mappers.Responses
{
  /// <summary>
  /// Maps feedback information and images to a feedback response.
  /// </summary>
  public class FeedbackResponseMapper : IFeedbackResponseMapper
  {
    private readonly IFeedbackInfoMapper _feedbackInfoMapper;
    private readonly IImageInfoMapper _imageInfoMapper;

    public FeedbackResponseMapper(
        IFeedbackInfoMapper feedbackInfoMapper,
        IImageInfoMapper imageInfoMapper)
    {
      _feedbackInfoMapper = feedbackInfoMapper;
      _imageInfoMapper = imageInfoMapper;
    }

    /// <inheritdoc/>
    public FeedbackResponse? Map(FeedbackInfo? feedbackInfo, IEnumerable<ImageInfo>? images)
    {
      if (feedbackInfo == null || images == null)
      {
        return null;
      }

      return new FeedbackResponse
      {
        Feedback = feedbackInfo,
        Images = images.ToList()
      };
    }
  }
}