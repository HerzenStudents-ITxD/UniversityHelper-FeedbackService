using UniversityHelper.FeedbackService.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using UniversityHelper.Core.EFSupport.Provider;

namespace UniversityHelper.FeedbackService.Data.Provider.MsSql.Ef;


public class FeedbackServiceDbContext : DbContext, IDataProvider
{
public FeedbackServiceDbContext(DbContextOptions<FeedbackServiceDbContext> options)
    : base(options)
{
}

public DbSet<DbFeedback> Feedbacks { get; set; }

public DbSet<DbImage> Images { get; set; }
    // Fluent API is written here.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("UniversityHelper.FeedbackService.Models.Db"));
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


    public object MakeEntityDetached(object obj)
    {
        Entry(obj).State = EntityState.Detached;
        return Entry(obj).State;
    }

    async Task IBaseDataProvider.SaveAsync()
    {
        await SaveChangesAsync();
    }

    void IBaseDataProvider.Save()
    {
        SaveChanges();
    }

    public void EnsureDeleted()
    {
        Database.EnsureDeleted();
    }

    public bool IsInMemory()
    {
        return Database.IsInMemory();
    }
}