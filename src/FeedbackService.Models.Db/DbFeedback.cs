using System;
using System.Collections.Generic;

namespace UniversityHelper.FeedbackService.Models.Db;

public class DbFeedback
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public int Status { get; set; }
    public required string SenderEmail { get; set; }
    public Guid SenderId { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public List<DbImage> Images { get; set; }
    public List<DbFeedbackType> FeedbackTypes { get; set; }

    public DbFeedback(string content, string senderEmail, Guid senderId)
    {
        Id = Guid.NewGuid();
        Content = content;
        SenderEmail = senderEmail;
        SenderId = senderId;
        CreatedAtUtc = DateTime.UtcNow;
        Images = new List<DbImage>();
        FeedbackTypes = new List<DbFeedbackType>();
    }
}