using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.UserRepositories;

internal sealed class AdminRepository : RepositoryBase<Admin>, IAdminRepository
{
    public AdminRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Admin>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .Include(a => a.ApplicationUser)
                    .Include(a => a.HealthCenter)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Admin> GetEntityAsync(Guid adminId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(adminId), trackChanges)
                .Include(a => a.ApplicationUser)
                .Include(a => a.HealthCenter)
                .SingleOrDefaultAsync();

    public void CreateEntity(Admin admin) => Create(admin);

    public void DeleteEntity(Admin admin) => Delete(admin);

    public void UpdateEntity(Admin entity) => Update(entity);
}
