using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repository;

public class SqlRegionRepository(NZWalksDbContext dbContext) : IRegionRepository
{
    private readonly NZWalksDbContext _db = dbContext;
    public async Task<IEnumerable<Region>> GetAll()
    {
        return await _db.Region.ToListAsync();
    }
}