using SedisBackend.Core.Application.Interfaces.Repositories.Users.Doctors;
using SedisBackend.Core.Domain.Users.Doctors;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Users.Doctors
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(SedisContext context) : base(context)
        {
        }
    }
}
