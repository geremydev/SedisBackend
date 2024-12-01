using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Models;

public interface IAppointmentRepository : IGenericRepository<Appointment>
{
    Task<ICollection<Appointment>> GetAppointmentsByPatientAsync(Guid patientId, bool trackChanges);
    Task<ICollection<Appointment>> GetAppointmentsByDoctor(Guid doctorId, bool trackChanges);
}
