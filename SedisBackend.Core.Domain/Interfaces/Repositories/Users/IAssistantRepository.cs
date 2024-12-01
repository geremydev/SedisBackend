using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Users;

public interface IAssistantRepository : IGenericRepository<Assistant>
{
    ICollection<Assistant> GetByHealthCenterId(Guid HealthCenterId);
}
