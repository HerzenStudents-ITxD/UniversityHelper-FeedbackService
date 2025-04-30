using UniversityHelper.FeedbackService.Models.Dto.Enums;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests
{
  public record EditFeedbackRequest
  {
    public FeedbackType Type { get; set; }

    public required string Content { get; set; }

    public FeedbackStatusType Status { get; set; }
  }
}