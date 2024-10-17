using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Locations;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Locations;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Locations;

namespace SedisBackend.Core.Application.Services.Domain_Services.Locations
{
    public class LocationService : GenericService<SaveLocationDto, BaseLocationDto, Location>, ILocationService
    {
        public LocationService(IGenericRepository<Location> repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }
    }
}
