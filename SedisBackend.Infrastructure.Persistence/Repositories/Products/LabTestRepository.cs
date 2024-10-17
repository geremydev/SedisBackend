using SedisBackend.Core.Application.Interfaces.Repositories.Products;
using SedisBackend.Core.Domain.Products;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Products
{
    public class LabTestRepository : GenericRepository<LabTest>, ILabTestRepository
    {
        public LabTestRepository(SedisContext context) : base(context)
        {
        }
    }
}
