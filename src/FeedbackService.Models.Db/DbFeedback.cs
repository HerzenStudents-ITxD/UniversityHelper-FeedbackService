using System;
using System.Collections.Generic;

namespace UniversityHelper.FeedbackService.Models.Db
{
  /// <summary>
  /// Represents a feedback entity in the database.
  /// </summary>
  public class DbFeedback
  {
    /// <summary>
    /// Gets or sets the feedback ID.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the feedback type.
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// Gets or sets the feedback content.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// Gets or sets the status of the feedback.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Gets or sets the full name of the sender.
    /// </summary>
    public required string SenderFullName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the sender.
    /// </summary>
    public Guid SenderId { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the feedback.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Gets or sets the IP address of the sender.
    /// </summary>
    public required string SenderIp { get; set; }

    /// <summary>
    /// Gets or sets the list of images associated with the feedback.
    /// </summary>
    public List<DbImage> Images { get; set; } = new List<DbImage>();
  }
}