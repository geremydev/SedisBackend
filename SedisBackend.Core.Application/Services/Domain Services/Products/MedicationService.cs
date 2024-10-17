
using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Products;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Products;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Products;

namespace SedisBackend.Core.Application.Services.Domain_Services.Products
{
    public class MedicationService : GenericService<SaveMedicationDto, BaseMedicationDto, Medication>, IMedicationService
    {
        public MedicationService(IGenericRepository<Medication> repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }
    }
}
