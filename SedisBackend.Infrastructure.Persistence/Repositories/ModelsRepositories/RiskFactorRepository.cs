using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class RiskFactorRepository : RepositoryBase<RiskFactor>, IRiskFactorRepository
{
    public RiskFactorRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<RiskFactor>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<RiskFactor> GetEntityAsync(Guid riskFactorId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(riskFactorId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(RiskFactor riskFactor) => Create(riskFactor);

    public void DeleteEntity(RiskFactor riskFactor) => Delete(riskFactor);
}
