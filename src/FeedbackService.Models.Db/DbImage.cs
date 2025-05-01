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

    //public DbImage(string name, string content, string extension, Guid feedbackId)
    //{
    //    Id = Guid.NewGuid();
    //    Name = name;
    //    Content = content;
    //    Extension = extension;
    //    FeedbackId = feedbackId;
    //    CreatedAtUtc = DateTime.UtcNow;
    //}
}