using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientDiscapacityRepository
{
    Task<IEnumerable<PatientDiscapacity>> GetAllEntitiesAsync(bool trackChanges);
    Task<IEnumerable<PatientDiscapacity>> GetPatientDiscapacities(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientDiscapacity>> GetPatientsWithDispacity(string discapacityICDCode, bool trackChanges);
    void CreateEntity(PatientDiscapacity entity);
    void DeleteEntity(PatientDiscapacity entity);
}
