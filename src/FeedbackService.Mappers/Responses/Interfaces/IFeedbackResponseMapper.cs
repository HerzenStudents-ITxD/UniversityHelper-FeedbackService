using HerzenHelper.FeedbackService.Models.Db;
using HerzenHelper.FeedbackService.Models.Dto;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.FeedbackService.Mappers.Responses.Interfaces
{
  [AutoInject]
  public interface IFeedbackResponseMapper
  {
    FeedbackResponse Map(DbFeedback dbFeedback);
  }
}
