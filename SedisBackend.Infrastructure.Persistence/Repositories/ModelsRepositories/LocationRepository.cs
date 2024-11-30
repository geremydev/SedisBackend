using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories.Models;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class LocationRepository : RepositoryBase<Location>, ILocationRepository
{
    public LocationRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Location>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Location> GetEntityAsync(Guid locationId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(locationId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(Location location) => Create(location);

    public void DeleteEntity(Location location) => Delete(location);

    public void UpdateEntity(Location entity) => Update(entity);
}
