using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.User_Entity_Relation;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Repositories.UserEntityRelations;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.User_Entity_Relation;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.UserEntityRelation;

namespace SedisBackend.Core.Application.Services.Domain_Services.User_Entity_Relation
{
    public class UserEntityRelationService : GenericService<SaveUserEntityRelationDto, BaseUserEntityRelationDto, UserEntityRelation>, IUserEntityRelationService
    {
        private readonly IGenericRepository<UserEntityRelation> _repository;

        public UserEntityRelationService(IGenericRepository<UserEntityRelation> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<List<UserEntityRelation>> GetByUserIdAsync(string UserId)
        {
            var allUER = await _repository.GetAllAsync();
            var relatedUER = allUER.FindAll(e => e.UserId == UserId);
            return relatedUER;
        }
    }
}