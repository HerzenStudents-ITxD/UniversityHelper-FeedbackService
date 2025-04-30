namespace UniversityHelper.FeedbackService.Models.Dto.Models
{
  /// <summary>
  /// Represents the content of an image in a feedback request.
  /// </summary>
  public record ImageContent
  
{
        /// <summary>
        /// Gets or sets the image name.
        /// </summary>
        public required string Name { get; set; }

  /// <summary>
  /// Gets or sets the image content.
  /// </summary>
  public required string Content { get; set; }

  /// <summary>
  /// Gets or sets the image extension.
  /// </summary>
  public required string Extension { get; set; }
}
}