using UniversityHelper.FeedbackService.Models.Dto.Enums;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests
{
  /// <summary>
  /// Request for editing feedback details.
  /// </summary>
  public record EditFeedbackRequest
  {
    /// <summary>
    /// Gets or sets the feedback type.
    /// </summary>
    public FeedbackType Type { get; set; }

    /// <summary>
    /// Gets or sets the feedback content.
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// Gets or sets the feedback status.
    /// </summary>
    public FeedbackStatusType Status { get; set; }
  }
}