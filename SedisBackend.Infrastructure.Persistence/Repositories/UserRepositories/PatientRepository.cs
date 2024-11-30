using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.UserRepositories;

internal sealed class PatientRepository : RepositoryBase<Patient>, IPatientRepository
{
    public PatientRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Patient>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .Include(p => p.ApplicationUser)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Patient> GetEntityAsync(Guid patientId, bool trackChanges)
    {
        var patient = await FindByCondition(c => c.Id.Equals(patientId), trackChanges)
            .Include(p => p.Allergies)
                .ThenInclude(pa => pa.Allergy)
            .Include(p => p.Illnesses)
                .ThenInclude(pi => pi.Illness)
            .Include(p => p.Discapacities)
                .ThenInclude(pd => pd.Discapacity)
            .Include(p => p.RiskFactors)
                .ThenInclude(pr => pr.RiskFactor)
            .Include(p => p.Vaccines)
                .ThenInclude(pv => pv.Vaccine)
            .Include(p => p.FamilyHistories)
            .Include(p => p.Appointments)
            .Include(p => p.ApplicationUser)
            .AsSplitQuery()
            .SingleOrDefaultAsync();

        if (patient == null)
            throw new KeyNotFoundException($"Patient with ID {patientId} not found.");

        return patient;
    }

    public void CreateEntity(Patient patient) => Create(patient);

    public void DeleteEntity(Patient patient) => Delete(patient);

    public void UpdateEntity(Patient entity) => Update(entity);
}
