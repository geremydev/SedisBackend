using SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Health_Centers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Health_Centers
{
    public interface IHealthCenterServicesService : IGenericService<SaveHealthCenterServicesDto, BaseHealthCenterServicesDto, HealthCenterServices>
    {
    }
}
