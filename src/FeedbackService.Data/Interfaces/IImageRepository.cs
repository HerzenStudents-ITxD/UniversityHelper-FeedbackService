using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Data.Interfaces;

[AutoInject]
public interface IImageRepository
{
Task CreateAsync(List<DbImage> images);

Task<List<ImageInfo>?> GetByFeedbackIdAsync(Guid feedbackId);
}