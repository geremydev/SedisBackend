using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Risk_Factor_Condition
{
    public interface IRiskFactorService : IGenericService<SaveRiskFactorDto, BaseRiskFactorDto, RiskFactor>
    {
    }
}
