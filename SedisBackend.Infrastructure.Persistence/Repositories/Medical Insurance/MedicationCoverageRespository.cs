using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories
{
    public class MedicationCoverageRespository : GenericRepository<MedicationCoverage>, IMedicationCoverageRepository
    {
        public MedicationCoverageRespository(SedisContext context) : base(context)
        {
        }
    }
}
