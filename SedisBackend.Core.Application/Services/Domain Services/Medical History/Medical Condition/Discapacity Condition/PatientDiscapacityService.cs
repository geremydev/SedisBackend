using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Medical_Condition.Discapacity_Condition
{
    public class PatientDiscapacityService : GenericService<SavePatientDiscapacityDto, BasePatientDiscapacityDto, PatientDiscapacity>, IPatientDiscapacityService
    {
        public PatientDiscapacityService(IGenericRepository<PatientDiscapacity> repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }
    }
}
