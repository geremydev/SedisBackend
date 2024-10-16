using SedisBackend.Core.Application.Interfaces.Repositories.Prescriptions;
using SedisBackend.Core.Domain.Prescriptions;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Presctiption
{
    public class LabTestPrescriptionRepository : GenericRepository<LabTestPrescription>, ILabTestPrescriptionRepository
    {
        public LabTestPrescriptionRepository(SedisContext context) : base(context)
        {
        }
    }
}
