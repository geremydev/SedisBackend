using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;
internal class PatientMedicationPrescriptionRepository : RepositoryBase<PatientMedicationPrescription>, IPatientMedicationPrescriptionRepository
{
    public PatientMedicationPrescriptionRepository(SedisContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateEntity(PatientMedicationPrescription entity) => Create(entity);
    public void DeleteEntity(PatientMedicationPrescription entity) => Delete(entity);

    public async Task<IEnumerable<PatientMedicationPrescription>> GetAllEntitiesAsync(bool trackChanges) =>
            await GetAllEntitiesAsync(trackChanges);
    public async Task<PatientMedicationPrescription> GetEntityAsync(Guid entityId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(entityId), trackChanges)
                            .SingleOrDefaultAsync();
}



