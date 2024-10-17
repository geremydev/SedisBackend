using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Domain.Medical_History.Vaccines;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Medical_History
{
    public class VaccineRepository : GenericRepository<Vaccine>, IVaccineRepository
    {
        public VaccineRepository(SedisContext context) : base(context)
        {
        }
    }
}
