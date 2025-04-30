using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Data.Interfaces;

[AutoInject]
public interface IFeedbackRepository
{
    Task<Guid?> CreateAsync(DbFeedback dbFeedback);

    Task<(List<DbFeedback> feedbacks, int totalCount)> FindAsync(
                Guid? userId,
                FeedbackStatusType? status,
                FeedbackType? type,
                bool orderByDescending,
                int page,
                int pageSize,
                CancellationToken cancellationToken);

    Task<DbFeedback?> GetAsync(Guid feedbackId);

    Task<DbFeedback?> GetByIdAsync(Guid feedbackId);

    Task<bool> HaveSameStatusAsync(List<Guid> feedbackIds, FeedbackStatusType status);

    Task<bool> EditStatusesAsync(List<Guid> feedbackIds, FeedbackStatusType status);
}