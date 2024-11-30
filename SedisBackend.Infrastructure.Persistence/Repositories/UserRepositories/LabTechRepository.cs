using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.UserRepositories;
public class LabTechRepository : RepositoryBase<LabTech>, ILabTechRepository
{
    public LabTechRepository(SedisContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateEntity(LabTech entity)=> Create(entity);

    public void DeleteEntity(LabTech entity) => Delete(entity);

    public async Task<IEnumerable<LabTech>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .Include(p => p.ApplicationUser)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<LabTech> GetEntityAsync(Guid entityId, bool trackChanges)=>
        await FindByCondition(c => c.Id.Equals(entityId), trackChanges)
                    .Include(p => p.ApplicationUser)
                    .SingleOrDefaultAsync();

    public void UpdateEntity(LabTech entity) => Update(entity);
}
