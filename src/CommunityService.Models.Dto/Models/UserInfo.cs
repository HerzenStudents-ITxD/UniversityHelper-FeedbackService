using System;

namespace UniversityHelper.FeedbackService.Models.Dto.Models
{
  /// <summary>
  /// Represents information about a user.
  /// </summary>
  public record UserInfo
  {
    /// <summary>
    /// Gets or sets the user's unique identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the user's first name.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the user's last name.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Gets or sets the user's middle name.
    /// </summary>
    public string? MiddleName { get; set; }
  }
}