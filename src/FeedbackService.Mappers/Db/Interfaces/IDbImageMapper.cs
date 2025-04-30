using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;

namespace UniversityHelper.FeedbackService.Mappers.Db.Interfaces;


[AutoInject]
public interface IDbImageMapper
{
DbImage? Map(ImageContent? imageContent, Guid feedbackId);
}