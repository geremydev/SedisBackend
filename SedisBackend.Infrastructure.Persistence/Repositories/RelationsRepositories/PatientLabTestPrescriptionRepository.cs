using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
internal class PatientLabTestPrescriptionRepository : RepositoryBase<PatientIllness>, IPatientLabTestPrescriptionRepository
{
    public PatientLabTestPrescriptionRepository(SedisContext repositoryContext) : base(repositoryContext)
    {

    }

    public void CreateEntity(PatientLabTestPrescription entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteEntity(PatientLabTestPrescription entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PatientLabTestPrescription>> GetAllEntitiesAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<PatientLabTestPrescription> GetEntityAsync(Guid entityA, Guid entityB, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
