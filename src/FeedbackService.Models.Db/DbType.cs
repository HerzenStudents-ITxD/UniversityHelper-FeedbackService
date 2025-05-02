using System;
using System.Collections.Generic;

namespace UniversityHelper.FeedbackService.Models.Db;

public class DbType
{
    public Guid Id { get; set; }
    public int Type { get; set; }
    public string Name { get; set; } // Строка вида {"ru": "Пожелания", "en": "Wishes", "zh": "愿望"}
    public bool IsActive { get; set; }
    public List<DbFeedbackType> FeedbackTypes { get; set; }

    public DbType(int type, string name)
    {
        Id = Guid.NewGuid();
        Type = type;
        Name = name;
        IsActive = true;
        FeedbackTypes = new List<DbFeedbackType>();
    }
}