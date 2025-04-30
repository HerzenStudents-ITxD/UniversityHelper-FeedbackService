namespace UniversityHelper.FeedbackService.Models.Dto.Models
{
  public record ImageContent
  
{
        public required string Name { get; set; }

  public required string Content { get; set; }

  public required string Extension { get; set; }
}
}