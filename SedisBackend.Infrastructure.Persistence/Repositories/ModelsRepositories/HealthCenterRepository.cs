using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories.Models;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class HealthCenterRepository : RepositoryBase<HealthCenter>, IHealthCenterRepository
{
    public HealthCenterRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<HealthCenter>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<HealthCenter> GetEntityAsync(Guid healthCenterId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(healthCenterId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(HealthCenter healthCenter) => Create(healthCenter);

    public void DeleteEntity(HealthCenter healthCenter) => Delete(healthCenter);

    public void UpdateEntity(HealthCenter entity) => Update(entity);
}
