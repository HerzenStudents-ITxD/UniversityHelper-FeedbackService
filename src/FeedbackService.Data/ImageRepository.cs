using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Data
{
  /// <summary>
  /// Repository for managing images.
  /// </summary>
  public class ImageRepository : IImageRepository
  {
    private readonly IImageInfoMapper _imageInfoMapper;

    public ImageRepository(IImageInfoMapper imageInfoMapper)
    {
      _imageInfoMapper = imageInfoMapper;
    }

    /// <inheritdoc/>
    public Task<List<ImageInfo>?> GetByFeedbackIdAsync(Guid feedbackId)
    {
      // Placeholder implementation; replace with actual data access
      return Task.FromResult<List<ImageInfo>?>(null);
    }
  }
}