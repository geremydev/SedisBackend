using SedisBackend.Core.Application.Interfaces.Repositories.Products;
using SedisBackend.Core.Application.Interfaces.Repositories.UserEntityRelations;
using SedisBackend.Core.Domain.Products;
using SedisBackend.Core.Domain.UserEntityRelation;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.UserEntityRelations
{
    public class UserEntityRelationRepository : GenericRepository<UserEntityRelation>, IUserEntityRelationRepository
    {
        public UserEntityRelationRepository(SedisContext context) : base(context)
        {
        }

    }
}