using System;

namespace UniversityHelper.FeedbackService.Models.Dto.Models
{
  /// <summary>
  /// Represents information about an image.
  /// </summary>
  public record ImageInfo
  {
    /// <summary>
    /// Gets or sets the image ID.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the image name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the image content.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// Gets or sets the image extension.
    /// </summary>
    public required string Extension { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the image.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }
  }
}