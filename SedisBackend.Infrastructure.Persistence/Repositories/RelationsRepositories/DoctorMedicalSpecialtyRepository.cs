using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal sealed class DoctorMedicalSpecialtyRepository : RepositoryBase<DoctorMedicalSpecialty>, IDoctorMedicalSpecialtyRepository
{
    public DoctorMedicalSpecialtyRepository(SedisContext context) : base(context)
    {

    }

    public void CreateEntity(DoctorMedicalSpecialty entity) => Create(entity);
    public void DeleteEntity(DoctorMedicalSpecialty entity) => Delete(entity);

    public async Task<IEnumerable<DoctorMedicalSpecialty>> GetAllEntitiesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<DoctorMedicalSpecialty>> GetByDoctor(Guid doctorId, bool trackChanges)
    {
        return await FindByCondition(dms => dms.DoctorId.Equals(doctorId), trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<DoctorMedicalSpecialty>> GetByMedicalSpecialty(Guid medicalSpecialtyId, bool trackChanges)
    {
        return await FindByCondition(dms => dms.MedicalSpecialtyId.Equals(medicalSpecialtyId), trackChanges).ToListAsync();
    }

    public async Task<DoctorMedicalSpecialty> GetEntityAsync(Guid doctorId, Guid medicalSpecialtyId, bool trackChanges)
    {
        return await FindByCondition(dms => dms.DoctorId.Equals(doctorId) && dms.MedicalSpecialtyId.Equals(medicalSpecialtyId), trackChanges)
            .SingleOrDefaultAsync();
    }

    public Task<DoctorMedicalSpecialty> GetEntityAsync(Guid entityId, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void UpdateEntity(DoctorMedicalSpecialty entity) => Update(entity);
}
