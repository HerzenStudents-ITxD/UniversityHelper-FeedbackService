namespace UniversityHelper.FeedbackService.Models.Dto.Configurations
{
  /// <summary>
  /// Configuration for memory cache settings.
  /// </summary>
  public record MemoryCacheConfig
  {
    public const string SectionName = "MemoryCache";

    /// <summary>
    /// Gets or sets the cache lifetime in minutes.
    /// </summary>
    public double CacheLiveInMinutes { get; set; }
  }
}