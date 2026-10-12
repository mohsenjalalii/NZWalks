using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repository;

public class SqlWalkRepository(NZWalksDbContext dbContext) : IWalkRepository
{
    private readonly NZWalksDbContext _db = dbContext;

    public async Task<IEnumerable<Walk>> GetAllAsync()
    {
        return await _db.Walk.Include("Difficulty").Include("Region").ToListAsync();
    }

    public async Task<Walk?> GetById(Guid id)
    {
        return await _db.Walk.Include("Difficulty").Include("Region").FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<Walk> CreateAsync(Walk walk)
    {
        await _db.Walk.AddAsync(walk);
        await _db.SaveChangesAsync();

        return walk;
    }

    public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
    {
        Walk existWalk = await _db.Walk.FirstOrDefaultAsync(w => w.Id == id);

        if (existWalk == null) return null;

        existWalk.Name = walk.Name;
        existWalk.Description = walk.Description;
        existWalk.LengthInKm = walk.LengthInKm;
        existWalk.WalkImageUrl = walk.WalkImageUrl;
        existWalk.DifficultyId = walk.DifficultyId;
        existWalk.RegionId = walk.RegionId;
        await _db.SaveChangesAsync();

        return existWalk;
    }
}