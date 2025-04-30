using System;
using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.FeedbackService.Data.Interfaces;

[AutoInject]
public interface IFeedbackAgentRepository
{
    Task<bool> IsModeratorAsync(Guid userId, Guid feedbackId);
    Task<bool> IsAgentAsync(Guid userId, Guid feedbackId);
}