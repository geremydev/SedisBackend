using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Domain.Appointments;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Appointments
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
    }
}
