using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.EFSupport.Provider;
using UniversityHelper.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.FeedbackService.Data.Provider;

[AutoInject(InjectType.Scoped)]
public interface IDataProvider : IBaseDataProvider
{
  DbSet<DbFeedback> Feedbacks { get; set; }
  DbSet<DbImage> Images { get; set; }
}
