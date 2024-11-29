using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Models;

public interface IAppointmentRepository : IGenericRepository<Appointment>
{
    ICollection<Appointment> GetAppointmentsByPatientAsync(Guid patientId, bool trackChanges);
}
