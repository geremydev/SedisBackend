using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories.Models;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class PrescriptionRepository : RepositoryBase<Prescription>, IPrescriptionRepository
{
    public PrescriptionRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Prescription>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Prescription> GetEntityAsync(Guid prescriptionId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(prescriptionId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(Prescription prescription) => Create(prescription);

    public void DeleteEntity(Prescription prescription) => Delete(prescription);
}
