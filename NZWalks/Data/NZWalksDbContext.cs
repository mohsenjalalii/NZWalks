using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data;

public class NZWalksDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Region> Region { get; set; }
    public DbSet<Difficulty> Difficulty { get; set; }
    public DbSet<Walk> Walk { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        List<Difficulty> difficulties = new List<Difficulty>()
        {
          new Difficulty()
          {
             Id=Guid.Parse("0f4d67e6-a993-487b-852b-5c8e41c2621b"),
             Name="Easy"
          },
          new Difficulty()
          {
             Id=Guid.Parse("427a22f7-cceb-48ac-b381-529d46b7d35c"),
             Name="Medium"
          },
          new Difficulty()
          {
             Id=Guid.Parse("9f259eff-19a9-4937-a63d-9c9cc86716ed"),
             Name="Hard"
          },
        };

        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        List<Region> regions = new List<Region>()
        {
            new Region()
            {
                Id=Guid.Parse("41f97f75-a7b9-4b31-ad86-d5a1926e6a5b"),
                Name="Auckland",
                Code="AKL",
                RegionImageUrl="auckland image"
            }
        };

        modelBuilder.Entity<Region>().HasData(regions);
    }
}