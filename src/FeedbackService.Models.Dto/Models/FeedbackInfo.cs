using System;
using System.Collections.Generic;
using UniversityHelper.FeedbackService.Models.Dto.Enums;

namespace UniversityHelper.FeedbackService.Models.Dto.Models;

public record FeedbackInfo
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public required string SenderEmail { get; set; }
    public required List<Guid> TypeIds { get; set; }
    public FeedbackStatusType Status { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public int ImagesCount { get; set; }
}