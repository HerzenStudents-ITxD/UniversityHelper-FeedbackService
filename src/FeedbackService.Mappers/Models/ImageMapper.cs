using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;

namespace UniversityHelper.FeedbackService.Mappers.Models
{
  public class ImageMapper : IImageMapper
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

    public ImageContent? Map(DbImage? dbImage)
    {
      if (dbImage == null)
      {
        return null;
      }

      return new ImageContent
      {
        Name = dbImage.Name,
        Content = dbImage.Content,
        Extension = dbImage.Extension
      };
    }
  }
}