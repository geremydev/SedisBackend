using SedisBackend.Core.Application.Interfaces.Repositories.Users.Admins;
using SedisBackend.Core.Domain.Users.Admins;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Users.Admins
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(SedisContext context) : base(context)
        {
        }
    }
}
