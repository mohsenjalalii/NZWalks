using NZWalks.Models.Domain;

namespace NZWalks.Repository;

public class InMemoryRegionRepository : IRegionRepository
{
    public async Task<IEnumerable<Region>> GetAll()
    {
        return [
            new()
            {
                Id = Guid.NewGuid(),
                Code ="code 1",
                Name ="name 1",
            },
            new (){
                Id = Guid.NewGuid(),
                Code ="code 2",
                Name ="name 2",
            }
        ];
    }
}