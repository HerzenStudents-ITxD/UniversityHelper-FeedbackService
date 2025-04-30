using Microsoft.AspNetCore.Http;
using UniversityHelper.FeedbackService.Mappers.Db.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests;

namespace UniversityHelper.FeedbackService.Mappers.Db
{
    public class DbFeedbackMapper : IDbFeedbackMapper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbFeedbackMapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbFeedback Map(CreateFeedbackRequest request)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value ?? Guid.Empty.ToString();
            return new DbFeedback
            {
                Id = Guid.NewGuid(),
                Text = request.Text,
                Status = request.Status,
                CreatedBy = Guid.Parse(userId),
                CreatedAtUtc = DateTime.UtcNow
            };
        }
    }
}