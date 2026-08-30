using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repository;

public class SqlRegionRepository(NZWalksDbContext dbContext) : IRegionRepository
{
    private readonly NZWalksDbContext _db = dbContext;
    public async Task<IEnumerable<Region>> GetAllAsync()
    {
        return await _db.Region.ToListAsync();
    }

    public async Task<Region> GetByIdAsync(Guid id)
    {
        return await _db.Region.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Region> CreateAsync(Region region)
    {
        await _db.Region.AddAsync(region);
        await _db.SaveChangesAsync();

        return region;
    }

    public async Task<Region> UpdateAsync(Guid id, Region region)
    {
        Region existsRegion = await _db.Region.FirstOrDefaultAsync(r => r.Id == id);
        existsRegion.Code = region.Code;
        existsRegion.Name = region.Name;
        existsRegion.RegionImageUrl = region.RegionImageUrl;
        await _db.SaveChangesAsync();

        return existsRegion;
    }

    public async Task<Region> DeleteAsync(Guid id)
    {
        Region region = await _db.Region.FirstOrDefaultAsync(r => r.Id == id);
        _db.Region.Remove(region);
        await _db.SaveChangesAsync();

        return region;
    }
}