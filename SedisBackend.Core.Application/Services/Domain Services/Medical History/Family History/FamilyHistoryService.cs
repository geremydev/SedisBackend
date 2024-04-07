using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Family_History;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Family_History;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Medical_History.Family_History;

namespace SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Family_History
{
    public class FamilyHistoryService : GenericService<SaveFamilyHistoryDto, BaseFamilyHistoryDto, FamilyHistory>, IFamilyHistoryService
    {
        public FamilyHistoryService(IGenericRepository<FamilyHistory> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
