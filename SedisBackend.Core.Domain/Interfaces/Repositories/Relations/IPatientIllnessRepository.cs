using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientIllnessRepository
{
    Task<IEnumerable<PatientIllness>> GetAllEntitiesAsync(bool trackChanges);
    Task<IEnumerable<PatientIllness>> GetPatientIllnesses(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientIllness>> GetPatientsWithIllness(string illnessICDCode, bool trackChanges);
    void CreateEntity(PatientIllness entity);
    void DeleteEntity(PatientIllness entity);
}
