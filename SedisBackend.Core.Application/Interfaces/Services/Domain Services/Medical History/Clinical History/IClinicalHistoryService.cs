using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Clinical_History
{
    public interface IClinicalHistoryService : IGenericService<SaveClinicalHistoryDto, BaseClinicalHistoryDto, ClinicalHistory>
    {
    }
}
