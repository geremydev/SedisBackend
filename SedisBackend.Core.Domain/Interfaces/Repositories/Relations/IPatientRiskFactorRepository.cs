using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientRiskFactorRepository : IGenericRelationalRepository<PatientRiskFactor>
{
    Task<IEnumerable<PatientRiskFactor>> GetByPatient(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientRiskFactor>> GetByRiskFactor(Guid riskFactorId, bool trackChanges);
}
