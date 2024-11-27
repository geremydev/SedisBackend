using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientDiscapacityRepository : IGenericRelationalRepository<PatientDiscapacity>
{
    Task<IEnumerable<PatientDiscapacity>> GetPatientDiscapacities(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientDiscapacity>> GetPatientsWithDispacity(string discapacityICDCode, bool trackChanges);
    void CreateEntity(PatientDiscapacity entity);
    void DeleteEntity(PatientDiscapacity entity);
}
