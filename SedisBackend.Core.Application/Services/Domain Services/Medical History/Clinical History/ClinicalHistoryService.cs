using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Clinical_History
{
    public class ClinicalHistoryService : GenericService<SaveClinicalHistoryDto, BaseClinicalHistoryDto, ClinicalHistory>, IClinicalHistoryService
    {
        public ClinicalHistoryService(IGenericRepository<ClinicalHistory> repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }
    }
}
