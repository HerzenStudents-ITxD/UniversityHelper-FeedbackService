using HerzenHelper.FeedbackService.Models.Db;
using HerzenHelper.FeedbackService.Models.Dto.Models;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.FeedbackService.Mappers.Models.Interfaces
{
  [AutoInject]
  public interface IImageMapper
  {
    ImageContent Map(DbImage dbImage);
  }
}
