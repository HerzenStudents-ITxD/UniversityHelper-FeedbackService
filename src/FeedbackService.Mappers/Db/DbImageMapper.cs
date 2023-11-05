using HerzenHelper.FeedbackService.Mappers.Db.Interfaces;
using HerzenHelper.FeedbackService.Models.Db;
using HerzenHelper.FeedbackService.Models.Dto.Models;
using System;

namespace HerzenHelper.FeedbackService.Mappers.Db
{
  public class DbImageMapper : IDbImageMapper
  {
    public DbImage Map(ImageContent image, Guid feedbackId)
    {
      if (image is null)
      {
        return null;
      }

      return new DbImage
      {
        Id = Guid.NewGuid(),
        FeedbackId = feedbackId,
        Name = image.Name,
        Content = image.Content,
        Extension = image.Extension,
        CreatedAtUtc = DateTime.Now
      };
    }
  }
}
