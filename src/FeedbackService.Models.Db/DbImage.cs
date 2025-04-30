using System;

namespace UniversityHelper.FeedbackService.Models.Db;

public class DbImage
{
public Guid Id { get; set; }
public required string Name { get; set; }
public required string Content { get; set; }
public required string Extension { get; set; }
public DateTime CreatedAtUtc { get; set; }
public DbFeedback? Feedback { get; set; }
public Guid FeedbackId { get; set; }
}