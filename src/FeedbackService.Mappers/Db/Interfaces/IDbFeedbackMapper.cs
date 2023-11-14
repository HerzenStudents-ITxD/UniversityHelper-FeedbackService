using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.FeedbackService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbFeedbackMapper
{
  DbFeedback Map(CreateFeedbackRequest request);
}
