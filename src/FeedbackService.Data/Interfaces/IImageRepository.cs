using HerzenHelper.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.FeedbackService.Models.Db;

namespace HerzenHelper.FeedbackService.Data.Interfaces
{
  [AutoInject]
  public interface IImageRepository
  {
    Task<List<Guid>> CreateAsync(List<DbImage> dbImages);
  }
}
