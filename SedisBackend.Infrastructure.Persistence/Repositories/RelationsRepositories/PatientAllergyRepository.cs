using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal sealed class PatientAllergyRepository : RepositoryBase<PatientAllergy>, IPatientAllergyRepository
{
    public PatientAllergyRepository(SedisContext context) : base(context)
    {

    }

    public void CreateEntity(PatientAllergy entity) => Create(entity);

    public void DeleteEntity(PatientAllergy entity) => Delete(entity);

    public async Task<IEnumerable<PatientAllergy>> GetAllEntitiesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<PatientAllergy>> GetByAllergy(Guid allergyId, bool trackChanges)
    {
        return await FindByCondition(c => c.AllergyId.Equals(allergyId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.Allergy).ToListAsync();
    }

    public async Task<IEnumerable<PatientAllergy>> GetByPatient(Guid patientId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.Allergy).ToListAsync();
    }

    public async Task<PatientAllergy> GetEntityAsync(Guid patientId, Guid allergyId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId) && c.AllergyId.Equals(allergyId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.Allergy).SingleOrDefaultAsync();
    }

    public void UpdateEntity(PatientAllergy entity) => Update(entity);
}
