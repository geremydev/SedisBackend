using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Interfaces.Repositories.Models;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class MedicationRepository : RepositoryBase<Medication>, IMedicationRepository
{
    public MedicationRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Medication>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Medication> GetEntityAsync(Guid medicationId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(medicationId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(Medication medication) => Create(medication);

    public void DeleteEntity(Medication medication) => Delete(medication);

    public void UpdateEntity(Medication entity) => Update(entity);
}
