using UniversityHelper.FeedbackService.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UniversityHelper.Core.EFSupport.Provider;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace UniversityHelper.FeedbackService.Data.Provider.MsSql.Ef;

public class FeedbackServiceDbContext : DbContext, IDataProvider
{
    public FeedbackServiceDbContext(DbContextOptions<FeedbackServiceDbContext> options)
        : base(options)
    {
    }

    public DbSet<DbFeedback> Feedbacks { get; set; }
    public DbSet<DbImage> Images { get; set; }
    public DbSet<DbType> Types { get; set; }
    public DbSet<DbFeedbackType> FeedbackTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("UniversityHelper.FeedbackService.Models.Db"));

        modelBuilder.Entity<DbFeedback>()
            .ToTable("Feedbacks")
            .HasKey(f => f.Id);

        modelBuilder.Entity<DbImage>()
            .ToTable("Images")
            .HasKey(i => i.Id);

        modelBuilder.Entity<DbType>()
            .ToTable("Types")
            .HasKey(t => t.Id);

        modelBuilder.Entity<DbType>()
            .Property(t => t.IsActive)
            .HasDefaultValue(true);

        modelBuilder.Entity<DbFeedbackType>()
            .ToTable("FeedbackTypes")
            .HasKey(ft => ft.Id);

        modelBuilder.Entity<DbImage>()
            .HasOne(i => i.Feedback)
            .WithMany(f => f.Images)
            .HasForeignKey(i => i.FeedbackId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DbFeedbackType>()
            .HasOne(ft => ft.Feedback)
            .WithMany(f => f.FeedbackTypes)
            .HasForeignKey(ft => ft.FeedbackId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DbFeedbackType>()
            .HasOne(ft => ft.Type)
            .WithMany(t => t.FeedbackTypes)
            .HasForeignKey(ft => ft.TypeId)
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