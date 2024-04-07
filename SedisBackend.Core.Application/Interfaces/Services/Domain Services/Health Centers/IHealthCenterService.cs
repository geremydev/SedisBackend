using SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Health_Centers;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Health_Centers
{
    public interface IHealthCenterService : IGenericService<SaveHealthCenterDto, BaseHealthCenterDto, HealthCenter>
    {
    }
}
