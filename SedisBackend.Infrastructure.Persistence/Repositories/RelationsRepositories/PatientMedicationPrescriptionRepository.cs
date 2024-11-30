using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal sealed class PatientMedicationPrescriptionRepository : RepositoryBase<PatientMedicationPrescription>, IPatientMedicationPrescriptionRepository
{
    public PatientMedicationPrescriptionRepository(SedisContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateEntity(PatientMedicationPrescription entity) => Create(entity);
    public void DeleteEntity(PatientMedicationPrescription entity) => Delete(entity);

    public async Task<IEnumerable<PatientMedicationPrescription>> GetAllEntitiesAsync(bool trackChanges) =>
            await GetAllEntitiesAsync(trackChanges);

    public async Task<PatientMedicationPrescription> GetEntityAsync(Guid Id, bool trackChanges)
    {
        return await FindByCondition(c => c.Id.Equals(Id), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.MedicalConsultation)
                .Include(a => a.Medication).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<PatientMedicationPrescription>> GetByPatient(Guid patientId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.MedicalConsultation)
                .Include(a => a.Medication).ToListAsync();
    }

    public async Task<IEnumerable<PatientMedicationPrescription>> GetByMedicalConsultation(Guid medicalConsultationId, bool trackChanges)
    {
        return await FindByCondition(c => c.MedicalConsultationId.Equals(medicalConsultationId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.MedicalConsultation)
                .Include(a => a.Medication).ToListAsync();
    }

    public async Task<IEnumerable<PatientMedicationPrescription>> GetByMedication(Guid medicationId, bool trackChanges)
    {
        return await FindByCondition(c => c.MedicationId.Equals(medicationId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.MedicalConsultation)
                .Include(a => a.Medication).ToListAsync();
    }

    public void UpdateEntity(PatientMedicationPrescription entity) => Update(entity);

}
