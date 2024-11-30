using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal sealed class PatientVaccineRepository : RepositoryBase<PatientVaccine>, IPatientVaccineRepository
{
    public PatientVaccineRepository(SedisContext context) : base(context)
    {

    }

    public void CreateEntity(PatientVaccine entity) => Create(entity);

    public void DeleteEntity(PatientVaccine entity) => Delete(entity);

    public async Task<IEnumerable<PatientVaccine>> GetAllEntitiesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
                    .ToListAsync();
    }

    public async Task<IEnumerable<PatientVaccine>> GetByPatient(Guid patientId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.Vaccine).ToListAsync();
    }

    public async Task<IEnumerable<PatientVaccine>> GetByVaccine(Guid vaccineId, bool trackChanges)
    {
        return await FindByCondition(c => c.VaccineId.Equals(vaccineId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.Vaccine).ToListAsync();
    }

    public async Task<PatientVaccine> GetEntityAsync(Guid patientId, Guid vaccineId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId) && c.VaccineId.Equals(vaccineId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.Vaccine).SingleOrDefaultAsync();
    }

    public Task<PatientVaccine> GetEntityAsync(Guid entityId, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void UpdateEntity(PatientVaccine entity) => Update(entity);
}
