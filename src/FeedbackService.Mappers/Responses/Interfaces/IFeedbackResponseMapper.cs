using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System.Collections.Generic;
using UniversityHelper.FeedbackService.Models.Dto.Responses;

namespace UniversityHelper.FeedbackService.Mappers.Responses.Interfaces;

[AutoInject]
public interface IFeedbackResponseMapper
{
FeedbackResponse? Map(FeedbackInfo? feedbackInfo, IEnumerable<ImageInfo>? images);

FeedbackResponse? Map(DbFeedback? dbFeedback);
}