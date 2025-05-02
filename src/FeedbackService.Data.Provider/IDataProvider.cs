using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.EFSupport.Provider;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UniversityHelper.Core.Enums;

namespace UniversityHelper.FeedbackService.Data.Provider;

[AutoInject(InjectType.Scoped)]
public interface IDataProvider : IBaseDataProvider
{
    DbSet<DbFeedback> Feedbacks { get; set; }
    DbSet<DbImage> Images { get; set; }
    DbSet<DbType> Types { get; set; }
    DbSet<DbFeedbackType> FeedbackTypes { get; set; }
}