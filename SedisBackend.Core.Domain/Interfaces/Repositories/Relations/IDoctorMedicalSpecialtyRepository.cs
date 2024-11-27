using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IDoctorMedicalSpecialtyRepository : IGenericRelationalRepository<DoctorMedicalSpecialty>
{
    Task<IEnumerable<DoctorMedicalSpecialty>> GetByDoctor(Guid doctorId, bool trackChanges);
    Task<IEnumerable<DoctorMedicalSpecialty>> GetByMedicalSpecialty(Guid medicalSpecialtyId, bool trackChanges);
}
