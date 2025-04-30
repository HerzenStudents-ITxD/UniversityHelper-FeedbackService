using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Mappers.Models.Interfaces
{
  [AutoInject]
  public interface IFeedbackInfoMapper
  {
    FeedbackInfo? Map(DbFeedback? dbFeedback, int imagesCount);
  }
}