namespace UniversityHelper.FeedbackService.Models.Dto.Requests;

public record CreateTypeRequest
{
    public int Type { get; set; }
    public required string Name { get; set; }
}