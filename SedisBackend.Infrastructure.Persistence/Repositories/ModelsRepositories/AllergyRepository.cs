using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class AllergyRepository : RepositoryBase<Allergy>, IAllergyRepository
{
    public AllergyRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Allergy>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Allergy> GetEntityAsync(Guid allergyId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(allergyId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(Allergy allergy) => Create(allergy);

    public void DeleteEntity(Allergy allergy) => Delete(allergy);
}
