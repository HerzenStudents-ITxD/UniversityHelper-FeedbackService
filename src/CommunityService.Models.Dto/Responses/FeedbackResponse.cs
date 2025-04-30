using System.Collections.Generic;
using UniversityHelper.FeedbackService.Models.Dto.Models;

namespace UniversityHelper.FeedbackService.Models.Dto.Responses
{
    /// <summary>
    /// Represents a detailed response for a feedback.
    /// </summary>
    public record FeedbackResponse
    {
        /// <summary>
        /// Gets or sets the feedback information.
        /// </summary>
        public required FeedbackInfo Feedback { get; set; }

        /// <summary>
        /// Gets or sets the list of images associated with the feedback.
        /// </summary>
        public required List<ImageInfo> Images { get; set; }
    }
}