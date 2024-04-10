using SedisBackend.Core.Application.Interfaces.Repositories.Users.Assistants;
using SedisBackend.Core.Domain.Users.Assistants;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Users.Assistants
{
    public class AssistantRepository : GenericRepository<Assistant>, IAssistantRepository
    {
        public AssistantRepository(SedisContext context) : base(context)
        {
        }
    }
}
