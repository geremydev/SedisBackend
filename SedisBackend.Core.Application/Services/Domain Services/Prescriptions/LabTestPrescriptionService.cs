using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Presctiprions;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Prescriptions;

namespace SedisBackend.Core.Application.Services.Domain_Services.Prescriptions
{
    public class LabTestPrescriptionService : GenericService<SaveLabTestPrescriptionDto, BaseLabTestPrescriptionDto, LabTestPrescription>, ILabTestPrescriptionService
    {
        public LabTestPrescriptionService(IGenericRepository<LabTestPrescription> repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }
    }
}
