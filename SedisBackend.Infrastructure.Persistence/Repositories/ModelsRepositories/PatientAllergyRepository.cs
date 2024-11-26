using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class PatientAllergyRepository : RepositoryBase<PatientAllergy>, IPatientAllergyRepository
{
    public PatientAllergyRepository(SedisContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<PatientAllergy>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .Include(pa => pa.Allergy) // Incluye el detalle de la alergia
            .Include(pa => pa.Patient) // Incluye el detalle del paciente
            .AsSplitQuery()
            .ToListAsync();

    public async Task<PatientAllergy> GetEntityAsync(Guid patientId, Guid allergyId, bool trackChanges)
    {
        var patientAllergy = await FindByCondition(pa => pa.PatientId.Equals(patientId) && pa.AllergyId.Equals(allergyId), trackChanges)
            .Include(pa => pa.Allergy)
            .Include(pa => pa.Patient)
            .AsSplitQuery()
            .SingleOrDefaultAsync();

        if (patientAllergy == null)
            throw new KeyNotFoundException($"Patient allergy with patient Id: {patientId}, and allergy Id: {allergyId} not found.");

        return patientAllergy;
    }

    public async Task<IEnumerable<PatientAllergy>> GetAllByPatientIdAsync(Guid patientId, bool trackChanges) =>
        await FindByCondition(pa => pa.PatientId == patientId, trackChanges)
            .Include(pa => pa.Allergy)
            .AsSplitQuery()
            .ToListAsync();

    public void CreateEntity(PatientAllergy patientAllergy) => Create(patientAllergy);

    public void DeleteEntity(PatientAllergy patientAllergy) => Delete(patientAllergy);
}
