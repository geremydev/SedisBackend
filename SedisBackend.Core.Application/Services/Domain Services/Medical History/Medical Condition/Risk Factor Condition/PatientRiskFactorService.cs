using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Medical_Condition.Risk_Factor_Condition
{
    public class PatientRiskFactorService : GenericService<SavePatientRiskFactorDto, BasePatientRiskFactorDto, PatientRiskFactor>
    {
        public PatientRiskFactorService(IGenericRepository<PatientRiskFactor> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
