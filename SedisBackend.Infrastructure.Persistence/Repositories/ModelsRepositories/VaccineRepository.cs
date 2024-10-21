using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Domain.Medical_History.Vaccines;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class VaccineRepository : RepositoryBase<Vaccine>, IVaccineRepository
{
    public VaccineRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Vaccine>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Vaccine> GetEntityAsync(Guid vaccineId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(vaccineId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(Vaccine vaccine) => Create(vaccine);

    public void DeleteEntity(Vaccine vaccine) => Delete(vaccine);
}
