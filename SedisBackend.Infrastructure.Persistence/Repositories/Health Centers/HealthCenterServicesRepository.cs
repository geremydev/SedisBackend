using SedisBackend.Core.Application.Interfaces.Repositories.Health_Centers;
using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Health_Centers
{
    public class HealthCenterServicesRepository : GenericRepository<HealthCenterServices>, IHealthCenterServicesRepository
    {
        public HealthCenterServicesRepository(SedisContext context) : base(context)
        {
        }
    }
}
