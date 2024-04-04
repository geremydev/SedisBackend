using SedisBackend.Core.Application.Interfaces.Repositories.Appointments;
using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Appointments
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(SedisContext context) : base(context)
        {
        }
    }
}
