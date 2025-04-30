using UniversityHelper.FeedbackService.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace UniversityHelper.FeedbackService.Data.Provider.MsSql.Ef
{

  public class FeedbackServiceDbContext : DbContext
  {
    public FeedbackServiceDbContext(DbContextOptions<FeedbackServiceDbContext> options)
        : base(options)
    {
    }

    public DbSet<DbFeedback> Feedbacks { get; set; }

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