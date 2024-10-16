using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories
{
    public class MedicationCoverageRepository : GenericRepository<MedicationCoverage>, IMedicationCoverageRepository
    {
        public MedicationCoverageRepository(SedisContext context) : base(context)
        {
        }
    }
}
