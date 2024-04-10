using SedisBackend.Core.Application.Dtos.Domain_Dtos.User_Entity_Relation;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.UserEntityRelation;


namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.User_Entity_Relation
{
    public interface IUserEntityRelationService : IGenericService<SaveUserEntityRelationDto, BaseUserEntityRelationDto, UserEntityRelation>
    {
        Task<List<UserEntityRelation>> GetByUserIdAsync(string UserId);
    }
}
