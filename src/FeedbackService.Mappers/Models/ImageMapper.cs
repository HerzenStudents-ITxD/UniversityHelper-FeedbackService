using UniversityHelper.FeedbackService.Mappers.Models.Interfaces;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Mappers.Models
{
  public class ImageMapper : IImageMapper
  {
    public ImageContent Map(DbImage dbImage)
    {
      return dbImage is null
        ? null
        : new()
        {
          Name = dbImage.Name,
          Content = dbImage.Content,
          Extension = dbImage.Extension
        };
    }
  }
}
