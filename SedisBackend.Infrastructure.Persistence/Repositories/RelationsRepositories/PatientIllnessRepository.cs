﻿using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal sealed class PatientIllnessRepository : RepositoryBase<PatientIllness>, IPatientIllnessRepository
{
    public PatientIllnessRepository(SedisContext repositoryContext) : base(repositoryContext)
    {

    }

    public async Task<IEnumerable<PatientIllness>> GetAllEntitiesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
                    .ToListAsync();
    }

    public async Task<PatientIllness> GetEntityAsync(Guid patientId, Guid illnessId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId) && c.IllnessId.Equals(illnessId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.Illness).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<PatientIllness>> GetByPatient(Guid patientId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId), trackChanges)
                .Include(a => a.Patient)
                .Include(a => a.Illness).ToListAsync();
    }

    public async Task<IEnumerable<PatientIllness>> GetByIllness(string illnessICDCode, bool trackChanges)
    {
        return await FindByCondition(c => c.Illness.IcdCode.Equals(illnessICDCode), trackChanges)
            .Include(a => a.Patient)
            .Include(a => a.Illness).ToListAsync();
    }

    public void CreateEntity(PatientIllness entity) => Create(entity);

    public void DeleteEntity(PatientIllness entity) => Delete(entity);
}
