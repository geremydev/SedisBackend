using SedisBackend.Core.Application.Interfaces.Repositories.Health_Centers;
using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Health_Centers
{
    public class HealthCenterServicesRepository : GenericRepository<HealthCenterServices>, IHealthCenterServicesRepository
    {
        public HealthCenterServicesRepository(SedisContext context) : base(context)
        {
        }
    }
}
