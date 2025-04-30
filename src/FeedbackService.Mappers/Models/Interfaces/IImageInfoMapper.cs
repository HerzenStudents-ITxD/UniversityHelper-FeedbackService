using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Mappers.Models.Interfaces;

[AutoInject]
public interface IImageInfoMapper
{
    ImageInfo? Map(DbImage? dbImage);
}