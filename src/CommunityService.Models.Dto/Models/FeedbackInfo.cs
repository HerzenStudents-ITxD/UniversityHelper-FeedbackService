using System;
using UniversityHelper.FeedbackService.Models.Dto.Enums;

namespace UniversityHelper.FeedbackService.Models.Dto.Models
{
  /// <summary>
  /// Represents summarized information about a feedback.
  /// </summary>
  public record FeedbackInfo
  {
    /// <summary>
    /// Gets or sets the feedback ID.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the feedback content.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// Gets or sets the full name of the sender.
    /// </summary>
    public required string SenderFullName { get; set; }

    /// <summary>
    /// Gets or sets the type of feedback.
    /// </summary>
    public FeedbackType Type { get; set; }

    /// <summary>
    /// Gets or sets the status of the feedback.
    /// </summary>
    public FeedbackStatusType Status { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the feedback.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Gets or sets the number of images associated with the feedback.
    /// </summary>
    public int ImagesCount { get; set; }
  }
}