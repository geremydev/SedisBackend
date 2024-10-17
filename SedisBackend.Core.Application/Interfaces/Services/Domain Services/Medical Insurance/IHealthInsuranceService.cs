using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_Insurance
{
    public interface IHealthInsuranceService : IGenericService<SaveHealthInsuranceDto, BaseHealthInsuranceDto, HealthInsurance>
    {
    }
}
