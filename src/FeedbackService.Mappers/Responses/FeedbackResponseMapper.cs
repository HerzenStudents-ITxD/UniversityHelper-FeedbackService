using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Responses.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System.Collections.Generic;
using System.Linq;
using UniversityHelper.FeedbackService.Mappers.Models;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Mappers.Responses
{
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

    public FeedbackResponse? Map(DbFeedback? dbFeedback)
    {
      if (dbFeedback == null)
      {
        return null;
      }

      var feedbackInfo = _feedbackInfoMapper.Map(dbFeedback, dbFeedback.Images?.Count ?? 0);
      var images = dbFeedback.Images?
          .Select(img => _imageInfoMapper.Map(img))
          .Where(img => img != null)
          .ToList() ?? new List<ImageInfo>();

      return new FeedbackResponse
      {
        Feedback = feedbackInfo!,
        Images = images
      };
    }
  }
}