using Hudson.DB.Service;
using Microsoft.EntityFrameworkCore;

namespace Hudson.DB;

public class AppDbContext : DbContext
{
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<ServiceItemWork> ServiceItemWorks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var path = Path.Combine("..", "Hudson.DB", "app.db");
        if (File.Exists(path))
            options.UseSqlite($"Data Source={path}");
        else
            throw new FileNotFoundException("Can't find app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServiceCategory>()
            .HasMany<ServiceItemWork>(i => i.ServiceItemWorks);
    }
}
