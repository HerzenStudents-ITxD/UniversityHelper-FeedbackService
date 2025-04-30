using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Data.Interfaces
{
  /// <summary>
  /// Interface for managing image entities in the data store.
  /// </summary>
  [AutoInject]
  public interface IImageRepository
  {
    /// <summary>
    /// Creates multiple images in the data store.
    /// </summary>
    /// <param name="images">The list of images to create.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateAsync(List<DbImage> images);

    /// <summary>
    /// Retrieves images associated with a specific feedback ID.
    /// </summary>
    /// <param name="feedbackId">The ID of the feedback.</param>
    /// <returns>A list of image information, or null if none found.</returns>
    Task<List<ImageInfo>?> GetByFeedbackIdAsync(Guid feedbackId);
  }
}