using HerzenHelper.FeedbackService.Models.Db;
using HerzenHelper.FeedbackService.Models.Dto.Requests;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.FeedbackService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbFeedbackMapper
  {
    DbFeedback Map(CreateFeedbackRequest request);
  }
}
