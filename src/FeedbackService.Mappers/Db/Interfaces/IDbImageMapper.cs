using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using UniversityHelper.Core.Attributes;
using System;

namespace UniversityHelper.FeedbackService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbImageMapper
{
  DbImage Map(ImageContent image, Guid feedbackId);
}
