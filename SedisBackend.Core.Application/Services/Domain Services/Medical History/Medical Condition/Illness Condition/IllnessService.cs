using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Medical_Condition.Illness_Condition
{
    public class IllnessService : GenericService<SaveIllnessDto, BaseIllnessDto, Illness>, IIllnessService
    {
        public IllnessService(IGenericRepository<Illness> repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }
    }
}
