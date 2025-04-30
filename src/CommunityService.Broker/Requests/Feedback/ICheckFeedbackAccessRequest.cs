using System;

namespace UniversityHelper.Models.Broker.Requests.Feedback;

public interface ICheckFeedbackAccessRequest
{
    Guid UserId { get; set; }
    Guid FeedbackId { get; set; }
}