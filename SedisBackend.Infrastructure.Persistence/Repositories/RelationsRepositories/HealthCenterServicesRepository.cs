using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;

internal sealed class HealthCenterServicesRepository : RepositoryBase<HealthCenterServices>, IHealthCenterServicesRepository
{
    public HealthCenterServicesRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<HealthCenterServices>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.CreationDate)
                    .ToListAsync();

    public async Task<HealthCenterServices> GetEntityAsync(Guid healthCenterId, Guid serviceId, bool trackChanges) =>
        await FindByCondition(c => c.HealthCenterId.Equals(healthCenterId) && c.ServiceId.Equals(serviceId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(HealthCenterServices healthCenterServices) => Create(healthCenterServices);

    public void DeleteEntity(HealthCenterServices healthCenterServices) => Delete(healthCenterServices);

    public async Task<IEnumerable<HealthCenterServices>> GetByHealthCenter(Guid healthCenterId, bool trackChanges)
    {
        return await FindByCondition(c => c.HealthCenterId.Equals(healthCenterId), trackChanges)
                .Include(a => a.HealthCenter)
                .Include(a => a.Service).ToListAsync();
    }

    public async Task<IEnumerable<HealthCenterServices>> GetByService(Guid serviceId, bool trackChanges)
    {
        return await FindByCondition(c => c.ServiceId.Equals(serviceId), trackChanges)
                .Include(a => a.HealthCenter)
                .Include(a => a.Service).ToListAsync();
    }
}
