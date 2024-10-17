using SedisBackend.Core.Application.Interfaces.Repositories.Users.Doctors;
using SedisBackend.Core.Domain.Users.Doctors;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Users.Doctors
{
    public class MedicalSpecialtyRepository : GenericRepository<MedicalSpecialty>, IMedicalSpecialtyRepository
    {
        public MedicalSpecialtyRepository(SedisContext context) : base(context)
        {
        }
    }
}
