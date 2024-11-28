using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories.Models;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;
internal sealed class ServiceRepository : RepositoryBase<Service>, IServiceRepository
{
    public ServiceRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Service>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Service> GetEntityAsync(Guid serviceId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(serviceId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(Service service) => Create(service);

    public void DeleteEntity(Service service) => Delete(service);

    public void UpdateEntity(Service entity) => Update(entity);
}