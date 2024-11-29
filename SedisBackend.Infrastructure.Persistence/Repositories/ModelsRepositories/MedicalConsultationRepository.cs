using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Domain.Medical_History.MedicalConsultation;
using SedisBackend.Infrastructure.Persistence.Contexts;

namespace SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

internal sealed class MedicalConsultationRepository : RepositoryBase<MedicalConsultation>, IMedicalConsultationRepository
{
    public MedicalConsultationRepository(SedisContext repositoryContext)
    : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<MedicalConsultation>> GetAllEntitiesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
                    .OrderBy(c => c.Id)
                    .ToListAsync();

    public async Task<MedicalConsultation> GetEntityAsync(Guid clinicalHistoryId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(clinicalHistoryId), trackChanges)
                            .SingleOrDefaultAsync();

    public void CreateEntity(MedicalConsultation clinicalHistory) => Create(clinicalHistory);

    public void DeleteEntity(MedicalConsultation clinicalHistory) => Delete(clinicalHistory);

    public void UpdateEntity(MedicalConsultation entity) => Update(entity);
}
