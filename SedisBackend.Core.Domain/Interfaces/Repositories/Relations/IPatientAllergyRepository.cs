using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientAllergyRepository : IGenericRelationalRepository<PatientAllergy>
{
    Task<PatientAllergy> GetEntityAsync(Guid patientId, Guid allergyId, bool trackChanges);
}
