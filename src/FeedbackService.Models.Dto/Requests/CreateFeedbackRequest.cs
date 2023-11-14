using UniversityHelper.FeedbackService.Models.Dto.Enums;
using UniversityHelper.FeedbackService.Models.Dto.Models;
using UniversityHelper.Models.Broker.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests;

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
