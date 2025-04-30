using System;
using System.Collections.Generic;

namespace UniversityHelper.FeedbackService.Models.Db;

public class DbFeedback
{
public Guid Id { get; set; }
public int Type { get; set; }
public required string Content { get; set; }
public int Status { get; set; }
public required string SenderEmail { get; set; }
public Guid SenderId { get; set; }
public DateTime CreatedAtUtc { get; set; }
public List<DbImage> Images { get; set; } = new List<DbImage>();
}