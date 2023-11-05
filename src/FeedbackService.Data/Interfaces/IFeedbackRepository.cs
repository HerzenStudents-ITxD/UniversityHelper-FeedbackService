using HerzenHelper.FeedbackService.Models.Db;
using HerzenHelper.FeedbackService.Models.Dto.Enums;
using HerzenHelper.FeedbackService.Models.Dto.Requests.Filter;
using HerzenHelper.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HerzenHelper.FeedbackService.Data.Interfaces
{
  [AutoInject]
  public interface IFeedbackRepository
  {
    Task<(List<(DbFeedback dbFeedback, int imagesCount)> dbFeedbacks, int totalCount)> FindAsync(FindFeedbacksFilter filter);
    Task<DbFeedback> GetAsync(Guid feedbackId);
    Task<Guid?> CreateAsync(DbFeedback dbFeedback);
    Task<bool> EditStatusesAsync(List<Guid> feedbacksIds, FeedbackStatusType status);
    Task<bool> HaveSameStatusAsync(List<Guid> feedbackIds, FeedbackStatusType status);
  }
}
