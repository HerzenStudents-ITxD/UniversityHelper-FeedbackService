using System;

namespace UniversityHelper.FeedbackService.Models.Dto.Models;

public record UserInfo
{
public Guid Id { get; set; }

public required string FirstName { get; set; }

public required string LastName { get; set; }

public string? MiddleName { get; set; }
}