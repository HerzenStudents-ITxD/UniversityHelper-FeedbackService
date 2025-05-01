using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Enums;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System.Linq;

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
            SenderEmail = dbFeedback.SenderEmail,
            TypeIds = dbFeedback.FeedbackTypes.Select(ft => ft.TypeId).ToList(),
            Status = (FeedbackStatusType)dbFeedback.Status,
            CreatedAtUtc = dbFeedback.CreatedAtUtc,
            ImagesCount = imagesCount
        };
    }
}