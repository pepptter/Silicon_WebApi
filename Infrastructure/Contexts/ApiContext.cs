using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<SubscribersEntity> Subscribers { get; set; }
    public DbSet<CoursesEntity> Courses { get; set; }
    public DbSet<AuthorsEntity> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoursesEntity>()
            .HasMany(c => c.Authors)
            .WithMany(a => a.Courses)
            .UsingEntity(j => j.ToTable("CourseAuthors"));

    }
}
