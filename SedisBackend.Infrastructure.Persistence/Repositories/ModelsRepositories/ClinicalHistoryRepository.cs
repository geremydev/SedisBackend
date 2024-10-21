using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class ClinicalHistoryRepository : RepositoryBase<ClinicalHistory>, IClinicalHistoryRepository
{
    public ClinicalHistoryRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<ClinicalHistory>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<ClinicalHistory> GetEntityAsync(Guid clinicalHistoryId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(clinicalHistoryId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(ClinicalHistory clinicalHistory) => Create(clinicalHistory);

    public void DeleteEntity(ClinicalHistory clinicalHistory) => Delete(clinicalHistory);
}
