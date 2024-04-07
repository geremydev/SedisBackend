using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Health_Centers;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Health_Centers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Services.Domain_Services.Health_Centers
{
    public class HealthCenterService : GenericService<SaveHealthCenterDto, BaseHealthCenterDto, HealthCenter>, IHealthCenterService
    {
        public HealthCenterService(IGenericRepository<HealthCenter> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
