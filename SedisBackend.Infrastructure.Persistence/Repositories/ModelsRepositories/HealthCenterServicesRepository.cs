using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class HealthCenterServicesRepository : RepositoryBase<HealthCenterServices>, IHealthCenterServicesRepository
{
    public HealthCenterServicesRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<HealthCenterServices>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<HealthCenterServices> GetEntityAsync(Guid healthCenterServicesId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(healthCenterServicesId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(HealthCenterServices healthCenterServices) => Create(healthCenterServices);

    public void DeleteEntity(HealthCenterServices healthCenterServices) => Delete(healthCenterServices);
}
