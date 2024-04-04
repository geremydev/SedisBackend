using SedisBackend.Core.Application.Interfaces.Repositories.Prescriptions;
using SedisBackend.Core.Domain.Presctiptions;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Presctiption
{
    public class MedicationPrescriptionRepository : GenericRepository<MedicationPrescription>, IMedicationPrescriptionRepository
    {
        public MedicationPrescriptionRepository(SedisContext context) : base(context)
        {
        }
    }
}
