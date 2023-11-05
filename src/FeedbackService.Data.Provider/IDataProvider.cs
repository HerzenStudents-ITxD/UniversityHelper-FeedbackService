using HerzenHelper.FeedbackService.Models.Db;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.EFSupport.Provider;
using HerzenHelper.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace HerzenHelper.FeedbackService.Data.Provider
{
  [AutoInject(InjectType.Scoped)]
  public interface IDataProvider : IBaseDataProvider
  {
    DbSet<DbFeedback> Feedbacks { get; set; }
    DbSet<DbImage> Images { get; set; }
  }
}
