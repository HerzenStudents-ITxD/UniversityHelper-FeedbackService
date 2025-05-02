using System;

namespace UniversityHelper.FeedbackService.Models.Dto.Responses;

public record TypeResponse
{
    public Guid Id { get; set; }
    public int Type { get; set; }
    public required string Name { get; set; }
    public bool IsActive { get; set; }
}