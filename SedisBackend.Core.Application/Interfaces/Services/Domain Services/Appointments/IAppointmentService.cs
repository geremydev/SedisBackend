using SedisBackend.Core.Application.Dtos.Domain_Dtos.Appointments;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Appointments;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Appointments
{
    public interface IAppointmentService : IGenericService<SaveAppointmentDto, BaseAppointmentDto, Appointment>
    {
    }
}
