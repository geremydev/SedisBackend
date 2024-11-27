using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.UserRepositories;
public class RegistratorRepository : RepositoryBase<Registrator>, IRegistratorRepository
{
    public RegistratorRepository(SedisContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateEntity(Registrator entity)=> Create(entity);

    public void DeleteEntity(Registrator entity) => Delete(entity);

    public async Task<IEnumerable<Registrator>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .Include(p => p.ApplicationUser)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Registrator> GetEntityAsync(Guid entityId, bool trackChanges)=>
        await FindByCondition(c => c.Id.Equals(entityId), trackChanges)
                    .Include(p => p.ApplicationUser)
                    .SingleOrDefaultAsync();
}
