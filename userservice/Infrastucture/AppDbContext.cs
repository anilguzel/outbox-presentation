using Microsoft.EntityFrameworkCore;
using userservice.Entities;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()
            .UseNpgsql(@"User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=test;Integrated Security=true;Pooling=true;");
    }

    public DbSet<User> user { get; set; }
    public DbSet<IntegrationEvent> integrationevent { get; set; }
}