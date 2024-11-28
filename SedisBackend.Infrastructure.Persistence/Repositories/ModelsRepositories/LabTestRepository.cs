using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Interfaces.Repositories.Models;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class LabTestRepository : RepositoryBase<LabTest>, ILabTestRepository
{
    public LabTestRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<LabTest>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.TestName)
                    .ToListAsync();

    public async Task<LabTest> GetEntityAsync(Guid labTestId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(labTestId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(LabTest labTest) => Create(labTest);

    public void DeleteEntity(LabTest labTest) => Delete(labTest);

    public void UpdateEntity(LabTest entity) => Update(entity);
}
