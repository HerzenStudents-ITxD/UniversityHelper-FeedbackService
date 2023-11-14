using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Enums;
using UniversityHelper.FeedbackService.Models.Dto.Requests.Filter;
using UniversityHelper.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Data.Interfaces;

[AutoInject]
public interface IFeedbackRepository
{
  Task<(List<(DbFeedback dbFeedback, int imagesCount)> dbFeedbacks, int totalCount)> FindAsync(FindFeedbacksFilter filter);
  Task<DbFeedback> GetAsync(Guid feedbackId);
  Task<Guid?> CreateAsync(DbFeedback dbFeedback);
  Task<bool> EditStatusesAsync(List<Guid> feedbacksIds, FeedbackStatusType status);
  Task<bool> HaveSameStatusAsync(List<Guid> feedbackIds, FeedbackStatusType status);
}
