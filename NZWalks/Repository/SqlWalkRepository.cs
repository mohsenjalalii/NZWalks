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
    public async Task<Walk> CreateAsync(Walk walk)
    {
        await _db.Walk.AddAsync(walk);
        await _db.SaveChangesAsync();

        return walk;
    }
}