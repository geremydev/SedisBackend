using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IHealthCenterServicesRepository : IGenericRelationalRepository<HealthCenterServices>
{
    Task<IEnumerable<HealthCenterServices>> GetByHealthCenter(Guid healthCenterId, bool trackChanges);
    Task<IEnumerable<HealthCenterServices>> GetByService(Guid serviceId, bool trackChanges);
}
