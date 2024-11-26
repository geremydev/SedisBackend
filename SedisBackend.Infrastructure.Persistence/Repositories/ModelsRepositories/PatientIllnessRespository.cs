using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;
internal class PatientIllnessRespository : RepositoryBase<PatientIllness>, IPatientIllnessRepository
{
    public PatientIllnessRespository(SedisContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<PatientIllness>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();
    public async Task<IEnumerable<PatientIllness>> GetAllPatientsIllnessesAsync(Guid Id, bool trackChanges) =>
        await FindAll(trackChanges)
        .Where(c => c.PatientId == Id)
        .ToListAsync();

    public async Task<PatientIllness> GetEntityAsync(Guid illnessId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(illnessId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(PatientIllness illness) => Create(illness);

    public void DeleteEntity(PatientIllness illness) => Delete(illness);
}
