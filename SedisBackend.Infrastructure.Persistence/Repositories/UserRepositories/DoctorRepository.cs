using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.UserRepositories;

internal sealed class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
{
    public DoctorRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Doctor>> GetAllEntitiesAsync(bool trackChanges) =>
         await FindAll(trackChanges)
                    .Include(a => a.ApplicationUser)
                    .Include(p => p.Specialties)
                        .ThenInclude(pa => pa.MedicalSpecialty)
                    .OrderBy(c => c.Id)
                    .ToListAsync();
    public async Task<Doctor> GetEntityAsync(Guid doctorId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(doctorId), trackChanges)
                    .Include(p => p.Appointments)
                    .Include(p => p.CurrentlyWorkingHealthCenter)
                    .Include(p => p.MedicalConsultations)
                    .Include(p => p.ApplicationUser)
                    .Include(p => p.Specialties)
                        .ThenInclude(pa => pa.MedicalSpecialty)
                    .AsSplitQuery()
                    .SingleOrDefaultAsync();

    public void CreateEntity(Doctor doctor) => Create(doctor);

    public void DeleteEntity(Doctor doctor) => Delete(doctor);

    public void UpdateEntity(Doctor entity) => Update(entity);

    public ICollection<Doctor> GetByHealthCenterId(Guid HealthCenterId) =>
         FindByCondition(c => c.CurrentlyWorkingHealthCenterId.Equals(HealthCenterId), true)
                          .Include(p => p.ApplicationUser)
                          .AsSplitQuery()
                          .ToList();
}
