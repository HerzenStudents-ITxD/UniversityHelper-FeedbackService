using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Mappers.Models;

public class ImageInfoMapper : IImageInfoMapper
{
public ImageInfo? Map(DbImage? dbImage)
{
  if (dbImage == null)
  {
    return null;
  }

  return new ImageInfo
  {
    Id = dbImage.Id,
    Name = dbImage.Name,
    Content = dbImage.Content,
    Extension = dbImage.Extension,
    CreatedAtUtc = dbImage.CreatedAtUtc
  };
}
}