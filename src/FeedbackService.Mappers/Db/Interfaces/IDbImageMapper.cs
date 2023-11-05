using HerzenHelper.FeedbackService.Models.Db;
using HerzenHelper.FeedbackService.Models.Dto.Models;
using HerzenHelper.Core.Attributes;
using System;

namespace HerzenHelper.FeedbackService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbImageMapper
  {
    DbImage Map(ImageContent image, Guid feedbackId);
  }
}
