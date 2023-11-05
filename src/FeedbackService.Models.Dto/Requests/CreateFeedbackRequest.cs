using HerzenHelper.FeedbackService.Models.Dto.Enums;
using HerzenHelper.FeedbackService.Models.Dto.Models;
using HerzenHelper.Models.Broker.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HerzenHelper.FeedbackService.Models.Dto.Requests
{
  public record CreateFeedbackRequest
  {
    public FeedbackType Type { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Content { get; set; }

    [Required]
    public List<ImageContent> FeedbackImages { get; set; }
    public UserData User { get; set; }
  }
}
