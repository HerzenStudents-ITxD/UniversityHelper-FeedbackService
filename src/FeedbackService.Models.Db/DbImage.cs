using System;

namespace UniversityHelper.FeedbackService.Models.Db
{
  /// <summary>
  /// Represents an image associated with a feedback in the database.
  /// </summary>
  public class DbImage
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

    /// <summary>
    /// Gets or sets the feedback associated with the image.
    /// </summary>
    public DbFeedback? Feedback { get; set; }

    /// <summary>
    /// Gets or sets the ID of the associated feedback.
    /// </summary>
    public Guid FeedbackId { get; set; }
  }
}