using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class AssistantRepository : RepositoryBase<Assistant>, IAssistantRepository
{
    public AssistantRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Assistant>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Assistant> GetEntityAsync(Guid assistantId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(assistantId), trackChanges)
                .SingleOrDefaultAsync();

    public void CreateEntity(Assistant assistant) => Create(assistant);

    public void DeleteEntity(Assistant assistant) => Delete(assistant);
}
