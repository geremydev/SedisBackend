using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Medical_History
{
    public class FamilyHistoryRepository : GenericRepository<FamilyHistory>, IFamilyHistoryRepository
    {
        public FamilyHistoryRepository(SedisContext context) : base(context)
        {
        }
    }
}
