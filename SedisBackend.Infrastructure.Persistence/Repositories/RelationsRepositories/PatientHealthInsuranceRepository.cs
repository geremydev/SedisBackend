using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal sealed class PatientHealthInsuranceRepository : RepositoryBase<PatientHealthInsurance>, IPatientHealthInsuranceRepository
{
    public PatientHealthInsuranceRepository(SedisContext context) : base(context)
    {

    }

    public void CreateEntity(PatientHealthInsurance entity) => Create(entity);

    public void DeleteEntity(PatientHealthInsurance entity) => Delete(entity);

    public async Task<IEnumerable<PatientHealthInsurance>> GetAllEntitiesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
                    .ToListAsync();
    }

    public async Task<IEnumerable<PatientHealthInsurance>> GetByHealthInsurance(Guid healthInsuranceId, bool trackChanges)
    {
        return await FindByCondition(c => c.HealthInsuranceId.Equals(healthInsuranceId), trackChanges)
                    .Include(a => a.Patient)
                    .Include(a => a.HealthInsurance).ToListAsync();
    }

    public async Task<IEnumerable<PatientHealthInsurance>> GetByPatient(Guid patientId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.HealthInsurance).ToListAsync();
    }

    public async Task<PatientHealthInsurance> GetEntityAsync(Guid patientId, Guid healthInsuranceId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId) && c.HealthInsuranceId.Equals(healthInsuranceId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.HealthInsurance).SingleOrDefaultAsync();
    }
}
