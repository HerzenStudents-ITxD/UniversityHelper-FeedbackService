using System;
using System.Collections.Generic;

namespace UniversityHelper.FeedbackService.Models.Db;

public class DbType
{
    public Guid Id { get; set; }
    public int Type { get; set; }
    public required string Name { get; set; }
    public List<DbFeedbackType> FeedbackTypes { get; set; }

    public DbType(int type, string name)
    {
        Id = Guid.NewGuid();
        Type = type;
        Name = name;
        FeedbackTypes = new List<DbFeedbackType>();
    }
}