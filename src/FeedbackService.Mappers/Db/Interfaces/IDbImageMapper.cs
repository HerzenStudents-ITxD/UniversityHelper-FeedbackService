using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;

namespace UniversityHelper.FeedbackService.Mappers.Db.Interfaces
{
  /// <summary>
  /// Interface for mapping image content to database image entities.
  /// </summary>
  [AutoInject]
  public interface IDbImageMapper
  {
    /// <summary>
    /// Maps image content to a database image entity.
    /// </summary>
    /// <param name="imageContent">The image content to map.</param>
    /// <param name="feedbackId">The ID of the associated feedback.</param>
    /// <returns>The mapped database image entity, or null if input is null.</returns>
    DbImage? Map(ImageContent? imageContent, Guid feedbackId);
  }
}