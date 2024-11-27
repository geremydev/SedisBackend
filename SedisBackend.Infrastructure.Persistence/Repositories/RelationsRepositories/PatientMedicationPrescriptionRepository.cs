using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal class PatientMedicationPrescriptionRepository : RepositoryBase<PatientMedicationPrescription>, IPatientMedicationPrescriptionRepository
{
    public PatientMedicationPrescriptionRepository(SedisContext repositoryContext) : base(repositoryContext)
    {

    }

    public void CreateEntity(PatientMedicationPrescription entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteEntity(PatientMedicationPrescription entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PatientMedicationPrescription>> GetAllEntitiesAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<PatientMedicationPrescription> GetEntityAsync(Guid entityId, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
