using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class FamilyHistoryRepository : RepositoryBase<FamilyHistory>, IFamilyHistoryRepository
{
    public FamilyHistoryRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<FamilyHistory>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<FamilyHistory> GetEntityAsync(Guid familyHistoryId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(familyHistoryId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(FamilyHistory familyHistory) => Create(familyHistory);

    public void DeleteEntity(FamilyHistory familyHistory) => Delete(familyHistory);

    public void UpdateEntity(FamilyHistory entity) => Update(entity);
}
