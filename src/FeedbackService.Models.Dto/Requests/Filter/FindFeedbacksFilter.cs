using UniversityHelper.FeedbackService.Models.Dto.Enums;
using UniversityHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests.Filter
{
  public record FindFeedbacksFilter : BaseFindFilter
  {
    [FromQuery(Name = "feedbackstatus")]
    public FeedbackStatusType? FeedbackStatus { get; set; }

    [FromQuery(Name = "feedbacktype")]
    public FeedbackType? FeedbackType { get; set; }

    [FromQuery(Name = "orderbydescending")]
    public bool OrderByDescending { get; set; } = false;
  }
}
