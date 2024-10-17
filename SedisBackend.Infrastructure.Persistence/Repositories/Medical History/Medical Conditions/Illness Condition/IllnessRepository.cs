using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Medical_History.Medical_Conditions.Illness_Condition
{
    public class IllnessRepository : GenericRepository<Illness>, IIllnessRepository
    {
        public IllnessRepository(SedisContext context) : base(context)
        {
        }
    }
}
