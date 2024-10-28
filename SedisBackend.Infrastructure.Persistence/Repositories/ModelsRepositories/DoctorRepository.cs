using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
{
    public DoctorRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Doctor>> GetAllEntitiesAsync(bool trackChanges) =>
         await FindAll(trackChanges)
                    .Include(a => a.ApplicationUser)
                    .OrderBy(c => c.Id)
                    .ToListAsync();
    public async Task<Doctor> GetEntityAsync(Guid doctorId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(doctorId), trackChanges)
                    .Include(p => p.Appointments)
                    .Include(p => p.CurrentlyWorkingHealthCenters)
                        .ThenInclude(hc => hc.HealthCenter)
                    .Include(p => p.DevelopedClinicalHistories)
                    .Include(p => p.ApplicationUser)
                    .Include(p => p.Specialties)
                        .ThenInclude(pa => pa.MedicalSpecialty)
                    .AsSplitQuery()
                    .SingleOrDefaultAsync();

    public void CreateEntity(Doctor doctor) => Create(doctor);

    public void DeleteEntity(Doctor doctor) => Delete(doctor);
}
