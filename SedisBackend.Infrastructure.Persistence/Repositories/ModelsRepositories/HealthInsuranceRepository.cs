using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class HealthInsuranceRepository : RepositoryBase<HealthInsurance>, IHealthInsuranceRepository
{
    public HealthInsuranceRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<HealthInsurance>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<HealthInsurance> GetEntityAsync(Guid healthInsuranceId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(healthInsuranceId), trackChanges)
                            .Include(p => p.MedicationCoverages)
                                 .ThenInclude(mc => mc.Medication)
                            .Include(p => p.SubscribedPatients)
                                .ThenInclude(sp => sp.Patient)
                                    .ThenInclude(p => p.ApplicationUser)
                            .AsSplitQuery()
                            .SingleOrDefaultAsync();

    public void CreateEntity(HealthInsurance healthInsurance) => Create(healthInsurance);

    public void DeleteEntity(HealthInsurance healthInsurance) => Delete(healthInsurance);
}
