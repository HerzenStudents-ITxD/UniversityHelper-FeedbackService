using UniversityHelper.FeedbackService.Mappers.Db.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;

namespace UniversityHelper.FeedbackService.Mappers.Db
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
