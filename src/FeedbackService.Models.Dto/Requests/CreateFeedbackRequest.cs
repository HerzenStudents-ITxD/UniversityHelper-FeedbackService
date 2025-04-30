using System;
using System.Collections.Generic;
using UniversityHelper.FeedbackService.Models.Dto.Enums;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Models.Dto.Requests;

public record CreateFeedbackRequest
{
public FeedbackType Type { get; set; }

public required string Content { get; set; }
public required int Status {  get; set; }
public required string Email { get; set; }

public required List<ImageContent> FeedbackImages { get; set; }

public required UserInfo User { get; set; }
}