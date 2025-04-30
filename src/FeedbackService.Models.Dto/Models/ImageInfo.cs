using System;

namespace UniversityHelper.FeedbackService.Models.Dto.Models
{
  public record ImageInfo
  {
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Content { get; set; }

    public required string Extension { get; set; }

    public DateTime CreatedAtUtc { get; set; }
  }
}