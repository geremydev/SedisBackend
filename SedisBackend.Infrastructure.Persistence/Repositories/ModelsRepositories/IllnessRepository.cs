using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class IllnessRepository : RepositoryBase<Illness>, IIllnessRepository
{
    public IllnessRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Illness>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Illness> GetEntityAsync(Guid illnessId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(illnessId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(Illness illness) => Create(illness);

    public void DeleteEntity(Illness illness) => Delete(illness);
}
