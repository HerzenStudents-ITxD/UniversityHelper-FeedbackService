using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;

namespace UniversityHelper.FeedbackService.Mappers.Models.Interfaces
{
  /// <summary>
  /// Interface for mapping between image content and database image entities.
  /// </summary>
  [AutoInject]
  public interface IImageMapper
  {
    /// <summary>
    /// Maps image content to a database image entity.
    /// </summary>
    /// <param name="imageContent">The image content to map.</param>
    /// <param name="feedbackId">The ID of the associated feedback.</param>
    /// <returns>The mapped database image entity, or null if input is null.</returns>
    DbImage? Map(ImageContent? imageContent, Guid feedbackId);

    /// <summary>
    /// Maps a database image entity to image content.
    /// </summary>
    /// <param name="dbImage">The database image entity to map.</param>
    /// <returns>The mapped image content, or null if input is null.</returns>
    ImageContent? Map(DbImage? dbImage);
  }
}