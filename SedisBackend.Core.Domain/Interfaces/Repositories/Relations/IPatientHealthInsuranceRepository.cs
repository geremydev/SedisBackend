using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientHealthInsuranceRepository : IGenericRelationalRepository<PatientHealthInsurance>
{
    Task<IEnumerable<PatientHealthInsurance>> GetByPatient(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientHealthInsurance>> GetByHealthInsurance(Guid healthInsuranceId, bool trackChanges);
}
