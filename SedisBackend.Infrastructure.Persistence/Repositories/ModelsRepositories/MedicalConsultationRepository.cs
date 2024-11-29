using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Domain.Medical_History.MedicalConsultation;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class MedicalConsultationRepository : RepositoryBase<MedicalConsultation>, IMedicalConsultationRepository
{
    public MedicalConsultationRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<MedicalConsultation>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<MedicalConsultation> GetEntityAsync(Guid clinicalHistoryId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(clinicalHistoryId), trackChanges)
                            .SingleOrDefaultAsync();

    public async Task<IEnumerable<MedicalConsultation>> GetByDoctor(Guid doctorId, bool trackChanges) =>
        await FindByCondition(c => c.DoctorId.Equals(doctorId), trackChanges)
                            .Include(m => m.Doctor)
                            .ToListAsync();

    public async Task<IEnumerable<MedicalConsultation>> GetByPatient(Guid patientId, bool trackChanges) =>
        await FindByCondition(c => c.PatientId.Equals(patientId), trackChanges)
                            .Include(m => m.Patient)
                            .ToListAsync();

    public void CreateEntity(MedicalConsultation clinicalHistory) => Create(clinicalHistory);

    public void DeleteEntity(MedicalConsultation clinicalHistory) => Delete(clinicalHistory);

    public void UpdateEntity(MedicalConsultation entity) => Update(entity);
}
