﻿using System;

namespace UniversityHelper.FeedbackService.Models.Db;

public class DbFeedbackType
{
    public Guid Id { get; set; }
    public Guid FeedbackId { get; set; }
    public DbFeedback Feedback { get; set; }
    public Guid TypeId { get; set; }
    public DbType Type { get; set; }

    //public DbFeedbackType(DbFeedback feedback, DbType type)
    //{
    //    Id = Guid.NewGuid();
    //    FeedbackId = feedback.Id;
    //    Feedback = feedback;
    //    TypeId = type.Id;
    //    Type = type;
    //}
}