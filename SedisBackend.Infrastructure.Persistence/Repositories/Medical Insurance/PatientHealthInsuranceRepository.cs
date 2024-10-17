using SedisBackend.Core.Application.Interfaces.Repositories.Medical_Insurance;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Medical_Insurance
{
    public class PatientHealthInsuranceRepository : GenericRepository<PatientHealthInsurance>, IPatientHealthInsuranceRepository
    {
        public PatientHealthInsuranceRepository(SedisContext context) : base(context)
        {
        }
    }
}
