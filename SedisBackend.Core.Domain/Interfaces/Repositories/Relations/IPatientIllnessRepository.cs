using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientIllnessRepository : IGenericRepository<PatientIllness>
{
    public Task<IEnumerable<PatientIllness>> GetAllPatientsIllnessesAsync(Guid Id, bool trackChanges);
}
