using HerzenHelper.FeedbackService.Mappers.Db.Interfaces;
using HerzenHelper.FeedbackService.Models.Db;
using HerzenHelper.FeedbackService.Models.Dto.Enums;
using HerzenHelper.FeedbackService.Models.Dto.Requests;
using System;
using System.Linq;

namespace HerzenHelper.FeedbackService.Mappers.Db
{
  public class DbFeedbackMapper : IDbFeedbackMapper
  {
    private readonly IDbImageMapper _imageMapper;

    public DbFeedbackMapper(IDbImageMapper imageMapper)
    {
      _imageMapper = imageMapper;
    }

    public DbFeedback Map(CreateFeedbackRequest request)
    {
      if (request is null)
      {
        return null;
      }

      Guid feedbackId = Guid.NewGuid();
      return new DbFeedback
      {
        Id = feedbackId,
        Type = (int)request.Type,
        Content = request.Content,
        Status = (int)FeedbackStatusType.New,
        SenderFullName = request.User is null ? string.Empty : $"{request.User.LastName} {request.User.FirstName} {request.User.MiddleName}",
        SenderId = request.User?.Id ?? Guid.Empty,
        SenderIp = string.Empty,
        CreatedAtUtc = DateTime.Now,
        Images = request.FeedbackImages
          .Select(fi => _imageMapper.Map(fi, feedbackId))
          .ToList()
      };
    }
  }
}
