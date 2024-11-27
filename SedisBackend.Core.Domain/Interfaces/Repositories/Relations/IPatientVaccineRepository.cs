using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientVaccineRepository : IGenericRelationalRepository<PatientVaccine>
{
    Task<IEnumerable<PatientVaccine>> GetByPatient(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientVaccine>> GetByVaccine(Guid vaccineId, bool trackChanges);
}
