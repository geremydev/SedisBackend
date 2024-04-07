using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_Insurance;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_Insurance
{
    public class HealthInsuranceService : GenericService<SaveHealthInsuranceDto, BaseHealthInsuranceDto, HealthInsurance>, IHealthInsuranceService
    {
        public HealthInsuranceService(IGenericRepository<HealthInsurance> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
