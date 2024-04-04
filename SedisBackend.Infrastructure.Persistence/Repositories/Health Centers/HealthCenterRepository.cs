using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories
{
    public class HealthCenterRepository : GenericRepository<HealthCenter>, IHealthCenterRepository
    {
        public HealthCenterRepository(SedisContext context) : base(context)
        {
        }
    }
}
