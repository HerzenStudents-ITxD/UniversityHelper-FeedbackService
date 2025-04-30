using UniversityHelper.FeedbackService.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace UniversityHelper.FeedbackService.Data.Provider.MsSql.Ef
{
  /// <summary>
  /// Database context for the FeedbackService using Entity Framework.
  /// </summary>
  public class FeedbackServiceDbContext : DbContext
  {
    public FeedbackServiceDbContext(DbContextOptions<FeedbackServiceDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the feedbacks table.
    /// </summary>
    public DbSet<DbFeedback> Feedbacks { get; set; }

    /// <summary>
    /// Gets or sets the images table.
    /// </summary>
    public DbSet<DbImage> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<DbFeedback>()
          .ToTable("Feedbacks")
          .HasKey(f => f.Id);

      modelBuilder.Entity<DbImage>()
          .ToTable("Images")
          .HasKey(i => i.Id);

      modelBuilder.Entity<DbImage>()
          .HasOne(i => i.Feedback)
          .WithMany(f => f.Images)
          .HasForeignKey(i => i.FeedbackId)
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}