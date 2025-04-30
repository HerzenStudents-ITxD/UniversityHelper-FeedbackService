using UniversityHelper.FeedbackService.Models.Dto.Enums;
using UniversityHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests;

public record FindFeedbacksRequest : BaseFindFilter
{
    [FromQuery(Name = "feedbackstatus")]
    public FeedbackStatusType? FeedbackStatus { get; set; }

    [FromQuery(Name = "feedbacktype")]
    public FeedbackType? FeedbackType { get; set; }

    [FromQuery(Name = "orderbydescending")]
    public bool OrderByDescending { get; set; } = false;

    [FromQuery(Name = "page")]
    public int Page { get; set; } = 1;

    [FromQuery(Name = "pageSize")]
    public int PageSize { get; set; } = 10;
}