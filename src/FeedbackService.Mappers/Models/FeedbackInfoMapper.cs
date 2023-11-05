using HerzenHelper.FeedbackService.Mappers.Models.Interfaces;
using HerzenHelper.FeedbackService.Models.Db;
using HerzenHelper.FeedbackService.Models.Dto.Enums;
using HerzenHelper.FeedbackService.Models.Dto.Models;

namespace HerzenHelper.FeedbackService.Mappers.Models
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
