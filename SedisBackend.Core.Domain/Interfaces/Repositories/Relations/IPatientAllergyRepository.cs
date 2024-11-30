using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientAllergyRepository : IGenericRelationalRepository<PatientAllergy>
{
    Task<PatientAllergy> GetEntityAsync(Guid patientId, Guid allergyId, bool trackChanges);
    Task<IEnumerable<PatientAllergy>> GetByPatient(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientAllergy>> GetByAllergy(Guid allergyId, bool trackChanges);
}
