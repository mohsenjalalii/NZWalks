using NZWalks.Models.Domain;

namespace NZWalks.Repository;

public interface IRegionRepository
{
    public Task<IEnumerable<Region>> GetAll();
}