using UniversityHelper.FeedbackService.Mappers.Db.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;

namespace UniversityHelper.FeedbackService.Mappers.Db
{
  public class DbImageMapper : IDbImageMapper
  {
    public DbImage? Map(ImageContent? imageContent, Guid feedbackId)
    {
      if (imageContent == null)
      {
        return null;
      }

      return new DbImage
      {
        Id = Guid.NewGuid(),
        Name = imageContent.Name,
        Content = imageContent.Content,
        Extension = imageContent.Extension,
        CreatedAtUtc = DateTime.UtcNow,
        FeedbackId = feedbackId
      };
    }
  }
}