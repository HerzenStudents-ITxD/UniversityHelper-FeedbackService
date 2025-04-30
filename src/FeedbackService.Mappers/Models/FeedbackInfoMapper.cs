using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Enums;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Mappers.Models;

public class FeedbackInfoMapper : IFeedbackInfoMapper
{
public FeedbackInfo? Map(DbFeedback? dbFeedback, int imagesCount)
{
  if (dbFeedback == null)
  {
    return null;
  }

  return new FeedbackInfo
  {
    Id = dbFeedback.Id,
    Content = dbFeedback.Content,
    SenderFullName = dbFeedback.SenderFullName,
    Type = (FeedbackType)dbFeedback.Type,
    Status = (FeedbackStatusType)dbFeedback.Status,
    CreatedAtUtc = dbFeedback.CreatedAtUtc,
    ImagesCount = imagesCount
  };
}
}