using System;
using System.Collections.Generic;
using UniversityHelper.FeedbackService.Models.Dto.Enums;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests
{
  public record EditFeedbackStatusesRequest
  {
    public required List<Guid> FeedbackIds { get; set; }

    public FeedbackStatusType Status { get; set; }
  }
}