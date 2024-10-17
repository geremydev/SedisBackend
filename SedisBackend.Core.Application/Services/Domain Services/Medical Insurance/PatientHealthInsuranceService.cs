using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_Insurance;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_Insurance
{
    public class PatientHealthInsuranceService : GenericService<SavePatientHealthInsuranceDto, BasePatientHealthInsuranceDto, PatientHealthInsurance>, IPatientHealthInsuranceService
    {
        public PatientHealthInsuranceService(IGenericRepository<PatientHealthInsurance> repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }
    }
}
