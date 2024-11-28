using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class MedicationCoverageRepository : RepositoryBase<MedicationCoverage>, IMedicationCoverageRepository
{
    public MedicationCoverageRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<MedicationCoverage>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<MedicationCoverage> GetEntityAsync(Guid medicationCoverageId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(medicationCoverageId), trackChanges)
                    .Include(p => p.HealthInsurance)
                    .Include(p => p.Medication)
                    .AsSplitQuery()
                    .SingleOrDefaultAsync();

    public void CreateEntity(MedicationCoverage medicationCoverage) => Create(medicationCoverage);

    public void DeleteEntity(MedicationCoverage medicationCoverage) => Delete(medicationCoverage);

    public void UpdateEntity(MedicationCoverage entity) => Update(entity);
}
