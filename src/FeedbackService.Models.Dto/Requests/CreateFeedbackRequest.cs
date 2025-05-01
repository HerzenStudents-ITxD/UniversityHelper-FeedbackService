using System;
using System.Collections.Generic;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests;

public record CreateFeedbackRequest
{
    public required List<Guid> TypeIds { get; set; }
    public required string Content { get; set; }
    public required int Status { get; set; }
    public required string Email { get; set; }
    public List<ImageContent>? FeedbackImages { get; set; }
    public UserInfo User { get; set; }
}