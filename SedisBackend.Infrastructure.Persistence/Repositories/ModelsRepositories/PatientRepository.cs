using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class PatientRepository : RepositoryBase<Patient>, IPatientRepository
{
    public PatientRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Patient>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Patient> GetEntityAsync(Guid patientId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(patientId), trackChanges)
                .SingleOrDefaultAsync();

    public void CreateEntity(Patient patient) => Create(patient);

    public void DeleteEntity(Patient patient) => Delete(patient);
}
