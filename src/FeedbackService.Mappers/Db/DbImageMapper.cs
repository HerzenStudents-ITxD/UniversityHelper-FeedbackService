using UniversityHelper.FeedbackService.Mappers.Db.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;

namespace UniversityHelper.FeedbackService.Mappers.Db
{
  /// <summary>
  /// Maps image content to database image entities.
  /// </summary>
  public class DbImageMapper : IDbImageMapper
  {
    /// <inheritdoc/>
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