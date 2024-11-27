using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientIllnessRepository : IGenericRelationalRepository<PatientIllness>
{
    Task<IEnumerable<PatientIllness>> GetByPatient(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientIllness>> GetByIllness(string illnessICDCode, bool trackChanges);
}
