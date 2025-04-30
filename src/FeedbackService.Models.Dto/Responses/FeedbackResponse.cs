using System.Collections.Generic;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Models.Dto.Responses
{
    public record FeedbackResponse
    {
        public required FeedbackInfo Feedback { get; set; }

        public required List<ImageInfo> Images { get; set; }
    }
}