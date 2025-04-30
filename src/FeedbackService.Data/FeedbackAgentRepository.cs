using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityHelper.FeedbackService.Data.Interfaces;
using UniversityHelper.FeedbackService.Data.Provider;

namespace UniversityHelper.FeedbackService.Data
{
    public class FeedbackAgentRepository : IFeedbackAgentRepository
    {
        private readonly IDataProvider _provider;

        public FeedbackAgentRepository(IDataProvider provider)
        {
            _provider = provider;
        }

        public async Task<bool> IsModeratorAsync(Guid userId, Guid feedbackId)
        {
            return await _provider.Feedbacks.AnyAsync(f => f.Id == feedbackId && f.CreatedBy == userId);
        }

        public async Task<bool> IsAgentAsync(Guid userId, Guid feedbackId)
        {
            return await _provider.Feedbacks.AnyAsync(f => f.Id == feedbackId && f.CreatedBy == userId);
        }
    }
}