using UniversityHelper.Core.Attributes;
using UniversityHelper.FeedbackService.Models.Db;
using UniversityHelper.FeedbackService.Models.Dto.Requests.Filter;
using UniversityHelper.FeedbackService.Models.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityHelper.FeedbackService.Data.Interfaces
{
  /// <summary>
  /// Interface for managing feedback entities in the data store.
  /// </summary>
  [AutoInject]
  public interface IFeedbackRepository
  {
    /// <summary>
    /// Creates a new feedback in the data store.
    /// </summary>
    /// <param name="dbFeedback">The feedback entity to create.</param>
    /// <returns>The ID of the created feedback, or null if creation failed.</returns>
    Task<Guid?> CreateAsync(DbFeedback dbFeedback);

    /// <summary>
    /// Retrieves feedbacks based on the specified filter.
    /// </summary>
    /// <param name="filter">The filter criteria.</param>
    /// <returns>A tuple containing the list of feedbacks with image counts and the total count.</returns>
    Task<(List<(DbFeedback dbFeedback, int imagesCount)>? dbFeedbacks, int totalCount)> FindAsync(FindFeedbacksFilter filter);

    /// <summary>
    /// Retrieves a feedback by its ID (alternative method).
    /// </summary>
    /// <param name="feedbackId">The ID of the feedback.</param>
    /// <returns>The feedback entity, or null if not found.</returns>
    Task<DbFeedback?> GetAsync(Guid feedbackId);

    /// <summary>
    /// Retrieves a feedback by its ID.
    /// </summary>
    /// <param name="feedbackId">The ID of the feedback.</param>
    /// <returns>The feedback entity, or null if not found.</returns>
    Task<DbFeedback?> GetByIdAsync(Guid feedbackId);

    /// <summary>
    /// Checks if any feedbacks have the specified status.
    /// </summary>
    /// <param name="feedbackIds">The list of feedback IDs to check.</param>
    /// <param name="status">The status to check for.</param>
    /// <returns>True if any feedback has the specified status, otherwise false.</returns>
    Task<bool> HaveSameStatusAsync(List<Guid> feedbackIds, FeedbackStatusType status);

    /// <summary>
    /// Updates the status of multiple feedbacks.
    /// </summary>
    /// <param name="feedbackIds">The list of feedback IDs to update.</param>
    /// <param name="status">The new status to set.</param>
    /// <returns>True if the update was successful, otherwise false.</returns>
    Task<bool> EditStatusesAsync(List<Guid> feedbackIds, FeedbackStatusType status);
  }
}