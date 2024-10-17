using SedisBackend.Core.Application.Interfaces.Repositories.Users.Patients;
using SedisBackend.Core.Domain.Users.Patients;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Users.Patients
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(SedisContext context) : base(context)
        {
        }
    }
}
