using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Repository;

public interface IWalkRepository
{
    Task<IEnumerable<Walk>> GetAllAsync();
    Task<Walk> GetById(Guid id);
    Task<Walk?> CreateAsync(Walk walk);
    Task<Walk?> UpdateAsync(Guid id, Walk walk);
}