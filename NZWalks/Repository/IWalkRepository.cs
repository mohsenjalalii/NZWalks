using NZWalks.Models.Domain;

namespace NZWalks.Repository;

public interface IWalkRepository
{
    Task<IEnumerable<Walk>> GetAllAsync();
    Task<Walk> GetById(Guid id);
    Task<Walk?> CreateAsync(Walk walk);
}