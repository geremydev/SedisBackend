using SedisBackend.Core.Application.Interfaces.Repositories.Locations;
using SedisBackend.Core.Domain.Locations;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Locations
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(SedisContext context) : base(context)
        {
        }
    }
}
