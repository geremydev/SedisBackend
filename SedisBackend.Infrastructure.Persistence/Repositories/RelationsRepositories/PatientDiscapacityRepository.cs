using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal sealed class PatientDiscapacityRepository : RepositoryBase<PatientDiscapacity>, IPatientDiscapacityRepository
{
    public PatientDiscapacityRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<PatientDiscapacity>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .ToListAsync();

    public async Task<IEnumerable<PatientDiscapacity>> GetPatientDiscapacities(Guid patientId, bool trackChanges) =>
        await FindByCondition(c => c.PatientId.Equals(patientId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.Discapacity).ToListAsync();

    public async Task<IEnumerable<PatientDiscapacity>> GetPatientsWithDispacity(string discapacityICDCode, bool trackChanges) =>
    await FindByCondition(c => c.Discapacity.IcdCode.Equals(discapacityICDCode), trackChanges)
            .Include(a => a.Patient)
            .Include(a => a.Discapacity).ToListAsync();

    public void CreateEntity(PatientDiscapacity pd) => Create(pd);

    public void DeleteEntity(PatientDiscapacity pd) => Delete(pd);

    public async Task<PatientDiscapacity> GetEntityAsync(Guid patientId, Guid discapacityId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId) && c.DiscapacityId.Equals(discapacityId), trackChanges)
                        .Include(a => a.Patient)
                        .Include(a => a.MedicalConsultation)
                        .Include(a => a.Discapacity).SingleOrDefaultAsync();
    }

    public void UpdateEntity(PatientDiscapacity entity) => Update(entity);
}