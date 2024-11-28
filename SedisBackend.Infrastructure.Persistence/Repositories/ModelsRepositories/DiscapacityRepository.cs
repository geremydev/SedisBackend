using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class DiscapacityRepository : RepositoryBase<Discapacity>, IDiscapacityRepository
{
    public DiscapacityRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Discapacity>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Discapacity> GetEntityAsync(Guid discapacityId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(discapacityId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(Discapacity discapacity) => Create(discapacity);

    public void DeleteEntity(Discapacity discapacity) => Delete(discapacity);

    public void UpdateEntity(Discapacity entity) => Update(entity);
}
