using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories.Models;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Appointment>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<Appointment> GetEntityAsync(Guid appointmentId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(appointmentId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(Appointment appointment) => Create(appointment);

    public void DeleteEntity(Appointment appointment) => Delete(appointment);

    public void UpdateEntity(Appointment entity) => Update(entity);
    public async Task<ICollection<Appointment>> GetAppointmentsByPatientAsync(Guid patientId, bool trackChanges)
    {
        return await FindByCondition(c => c.PatientId.Equals(patientId), trackChanges).ToListAsync();
    }

    public async Task<ICollection<Appointment>> GetAppointmentsByDoctor(Guid doctorId, bool trackChanges)
    {
        return await FindByCondition(c => c.DoctorId.Equals(doctorId), trackChanges).ToListAsync();
    }
}
