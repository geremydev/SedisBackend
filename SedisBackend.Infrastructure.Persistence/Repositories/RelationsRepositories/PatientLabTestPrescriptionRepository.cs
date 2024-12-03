using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal sealed class PatientLabTestPrescriptionRepository : RepositoryBase<PatientLabTestPrescription>, IPatientLabTestPrescriptionRepository
{
    public PatientLabTestPrescriptionRepository(SedisContext repositoryContext) : base(repositoryContext)
    {

    }

    public void CreateEntity(PatientLabTestPrescription entity) => Create(entity);

    public void DeleteEntity(PatientLabTestPrescription entity) => Delete(entity);

    public async Task<IEnumerable<PatientLabTestPrescription>> GetAllEntitiesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
                    .ToListAsync();
    }

    public async Task<PatientLabTestPrescription> GetEntityAsync(Guid patientId, Guid labTestId, bool trackChanges)
    {
        return await FindByCondition(plp => plp.PatientId.Equals(patientId) && plp.LabTest.Equals(labTestId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.LabTech)
                .Include(a => a.LabTest).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<PatientLabTestPrescription>> GetByPatient(Guid patientId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.LabTest).ToListAsync();
    }

    public async Task<IEnumerable<PatientLabTestPrescription>> GetByDoctor(Guid doctorId, bool trackChanges)
    {
        return await FindByCondition(c => c.DoctorId.Equals(doctorId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.LabTest).ToListAsync();
    }

    public async Task<IEnumerable<PatientLabTestPrescription>> GetByHealthCenter(Guid healthCenterId, bool trackChanges)
    {
        return await FindByCondition(c => c.Doctor.CurrentlyWorkingHealthCenterId.Equals(healthCenterId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.LabTest).ToListAsync();
    }

    public async Task<IEnumerable<PatientLabTestPrescription>> GetByLabTech(Guid labtestPrescriptionId, bool trackChanges)
    {
        return await FindByCondition(c => c.LabTestId.Equals(labtestPrescriptionId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.LabTest).ToListAsync();
    }

    public async Task<IEnumerable<PatientLabTestPrescription>> GetByLabTestPrescription(Guid labtestPrescriptionId, bool trackChanges)
    {
        return await FindByCondition(c => c.LabTest.Id.Equals(labtestPrescriptionId), trackChanges)
            .Include(a => a.Patient)
            .Include(a => a.LabTest).ToListAsync();
    }

    public void UpdateEntity(PatientLabTestPrescription entity) => Update(entity);

    public async Task<PatientLabTestPrescription> GetEntityAsync(Guid entityId, bool trackChanges)
    {
        return await GetEntityAsync(entityId, trackChanges);
    }
}
