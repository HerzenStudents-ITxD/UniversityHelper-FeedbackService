using HerzenHelper.FeedbackService.Mappers.Models.Interfaces;
using HerzenHelper.FeedbackService.Models.Db;
using HerzenHelper.FeedbackService.Models.Dto.Models;

namespace HerzenHelper.FeedbackService.Mappers.Models
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
