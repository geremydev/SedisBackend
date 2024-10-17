using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Vaccines;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Vaccines
{
    public class PatientVaccineService : GenericService<SavePatientVaccineDto, BasePatientVaccineDto, PatientVaccine>, IPatientVaccineService
    {
        public PatientVaccineService(IGenericRepository<PatientVaccine> repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }
    }
}
