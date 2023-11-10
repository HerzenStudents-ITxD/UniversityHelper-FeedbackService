using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.FeedbackService.Mappers.Responses.Interfaces
{
  [AutoInject]
  public interface IFeedbackResponseMapper
  {
    FeedbackResponse Map(DbFeedback dbFeedback);
  }
}
