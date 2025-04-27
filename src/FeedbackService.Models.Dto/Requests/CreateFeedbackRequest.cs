using System;
using System.Collections.Generic;
using UniversityHelper.FeedbackService.Models.Dto.Enums;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests
{
  /// <summary>
  /// Request for creating a new feedback.
  /// </summary>
  public record CreateFeedbackRequest
  {
    /// <summary>
    /// Gets or sets the type of feedback.
    /// </summary>
    public FeedbackType Type { get; set; }

    /// <summary>
    /// Gets or sets the feedback content.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// Gets or sets the list of images for the feedback.
    /// </summary>
    public required List<ImageContent> FeedbackImages { get; set; }

    /// <summary>
    /// Gets or sets the user who submitted the feedback.
    /// </summary>
    public required UserInfo User { get; set; }
  }
}