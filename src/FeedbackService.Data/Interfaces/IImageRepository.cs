using UniversityHelper.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.FeedbackService.Models.Db;

namespace UniversityHelper.FeedbackService.Data.Interfaces;

[AutoInject]
public interface IImageRepository
{
  Task<List<Guid>> CreateAsync(List<DbImage> dbImages);
}
