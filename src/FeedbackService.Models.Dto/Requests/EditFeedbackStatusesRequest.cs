using System;
using System.Collections.Generic;
using UniversityHelper.FeedbackService.Models.Dto.Enums;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests
{
  /// <summary>
  /// Request for editing the status of multiple feedbacks.
  /// </summary>
  public record EditFeedbackStatusesRequest
  {
    /// <summary>
    /// Gets or sets the list of feedback IDs to update.
    /// </summary>
    public required List<Guid> FeedbackIds { get; set; }

    /// <summary>
    /// Gets or sets the new status for the feedbacks.
    /// </summary>
    public FeedbackStatusType Status { get; set; }
  }
}