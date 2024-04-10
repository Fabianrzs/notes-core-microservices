using Microsoft.EntityFrameworkCore;
using Reservar.Common.Domain.Entities.Base;
using Notes.Domain.Entities;

namespace Notes.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

    public async Task CommitAsync()
    {
        await SaveChangesAsync().ConfigureAwait(false);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(DomainEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn").HasDefaultValueSql("GETDATE()");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn").HasDefaultValueSql("GETDATE()");
            }
        }

        modelBuilder.Entity<Note>()
            .HasOne(l => l.Category)
            .WithMany(m => m.Notes)
            .HasForeignKey(l => l.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }
}
