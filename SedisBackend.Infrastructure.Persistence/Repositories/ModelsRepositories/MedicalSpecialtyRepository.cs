using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class MedicalSpecialtyRepository : RepositoryBase<MedicalSpecialty>, IMedicalSpecialtyRepository
{
    public MedicalSpecialtyRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<MedicalSpecialty>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<MedicalSpecialty> GetEntityAsync(Guid medicalSpecialtyId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(medicalSpecialtyId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(MedicalSpecialty medicalSpecialty) => Create(medicalSpecialty);

    public void DeleteEntity(MedicalSpecialty medicalSpecialty) => Delete(medicalSpecialty);
}
