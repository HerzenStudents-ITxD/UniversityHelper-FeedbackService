using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Enums;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Mappers.Models
{
  public class FeedbackInfoMapper : IFeedbackInfoMapper
  {
    public FeedbackInfo Map(DbFeedback dbFeedback, int imagesCount)
    {
      if (dbFeedback is null)
      {
        return null;
      }

      return new FeedbackInfo
      {
        Id = dbFeedback.Id,
        Type = (FeedbackType)dbFeedback.Type,
        Content = dbFeedback.Content,
        Status = (FeedbackStatusType)dbFeedback.Status,
        SenderFullName = dbFeedback.SenderFullName,
        CreatedAtUtc = dbFeedback.CreatedAtUtc,
        ImagesCount = imagesCount
      };
    }
  }
}
