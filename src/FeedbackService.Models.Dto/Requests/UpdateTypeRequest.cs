using System;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests;

public record UpdateTypeRequest
{
    public Guid Id { get; set; }
    public int Type { get; set; }
    public required string Name { get; set; }
}