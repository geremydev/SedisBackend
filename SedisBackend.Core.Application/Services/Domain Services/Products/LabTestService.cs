using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Products;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Products;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Products;

namespace SedisBackend.Core.Application.Services.Domain_Services.Products
{
    public class LabTestService : GenericService<SaveLabTestDto, BaseLabTestDto, LabTest>, ILabTestService
    {
        public LabTestService(IGenericRepository<LabTest> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
