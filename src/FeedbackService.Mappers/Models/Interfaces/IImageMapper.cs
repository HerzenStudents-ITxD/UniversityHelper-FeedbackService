using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using System;

namespace UniversityHelper.FeedbackService.Mappers.Models.Interfaces
{
  [AutoInject]
  public interface IImageMapper
  {
    DbImage? Map(ImageContent? imageContent, Guid feedbackId);

    ImageContent? Map(DbImage? dbImage);
  }
}