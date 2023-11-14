using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.FeedbackService.Mappers.Models.Interfaces;

[AutoInject]
public interface IImageMapper
{
  ImageContent Map(DbImage dbImage);
}
