using SedisBackend.Core.Application.Dtos.Domain_Dtos.Locations;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Locations;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Locations
{
    public interface ILocationService : IGenericService<SaveLocationDto, BaseLocationDto, Location>
    {
    }
}
