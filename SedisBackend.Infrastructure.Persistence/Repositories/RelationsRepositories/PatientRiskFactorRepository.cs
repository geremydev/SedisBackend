using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal sealed class PatientRiskFactorRepository : RepositoryBase<PatientRiskFactor>, IPatientRiskFactorRepository
{
    public PatientRiskFactorRepository(SedisContext context) : base(context)
    {

    }

    public void CreateEntity(PatientRiskFactor entity) => Create(entity);
    public void DeleteEntity(PatientRiskFactor entity) => Delete(entity);

    public async Task<IEnumerable<PatientRiskFactor>> GetAllEntitiesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
                   .ToListAsync();
    }

    public async Task<IEnumerable<PatientRiskFactor>> GetByPatient(Guid patientId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.RiskFactor).ToListAsync();
    }

    public async Task<IEnumerable<PatientRiskFactor>> GetByRiskFactor(Guid riskFactorId, bool trackChanges)
    {
        return await FindByCondition(c => c.RiskFactor.Equals(riskFactorId), trackChanges)
            .Include(a => a.Patient)
            .Include(a => a.RiskFactor).ToListAsync();
    }

    public async Task<PatientRiskFactor> GetEntityAsync(Guid patientId, Guid riskFactorId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId) && c.RiskFactorId.Equals(riskFactorId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.RiskFactor).SingleOrDefaultAsync();
    }

    public Task<PatientRiskFactor> GetEntityAsync(Guid entityId, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void UpdateEntity(PatientRiskFactor entity) => Update(entity);
}
