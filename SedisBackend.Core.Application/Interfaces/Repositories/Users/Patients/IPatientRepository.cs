using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Users.Patients
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
    }
}
