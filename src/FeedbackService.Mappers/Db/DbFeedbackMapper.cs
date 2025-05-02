using Microsoft.AspNetCore.Http;
using UniversityHelper.FeedbackService.Mappers.Db.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests;
using System;
using UniversityHelper.Core.Extensions;

namespace UniversityHelper.FeedbackService.Mappers.Db;

public class DbFeedbackMapper : IDbFeedbackMapper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbFeedbackMapper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public DbFeedback Map(CreateFeedbackRequest request)
    {
        Guid senderId = Guid.Empty;

        try
        {
            senderId = _httpContextAccessor.HttpContext.GetUserId();
         
        }
        catch {}

        var feedback = new DbFeedback
        {
            Id = Guid.NewGuid(),
            Content = request.Content,
            SenderEmail = request.Email,
            Status = request.Status,
            Images = new(),
            SenderId = senderId,
            CreatedAtUtc = DateTime.UtcNow,
            FeedbackTypes = request.TypeIds.Select(typeId => new DbFeedbackType
            {
                Id = Guid.NewGuid(),
                TypeId = typeId
            }).ToList()
        };

        foreach (var feedbackType in feedback.FeedbackTypes)
        {
            feedbackType.FeedbackId = feedback.Id;
        }

        return feedback;
    }
}