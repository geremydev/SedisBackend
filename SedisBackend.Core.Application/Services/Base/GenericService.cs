using AutoMapper;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using System.Linq.Expressions;

namespace SedisBackend.Core.Application.Services.Base
{
    public class GenericService<SaveDto, BaseDto, Entity> : IGenericService<SaveDto, BaseDto, Entity>
            where SaveDto : class
            where BaseDto : class
            where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public virtual async Task<SaveDto> AddAsync(SaveDto vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            //Recordar que el profesor la devolvía para atrás la entidad
            entity = await _repository.AddAsync(entity);

            SaveDto svm = _mapper.Map<SaveDto>(entity);
            return svm;
        }

        public virtual async Task<List<BaseDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var newList = _mapper.Map<List<BaseDto>>(list);
            //Recordar revisar que devuelva los que su delete sea false.
            return newList;
        }

        public virtual async Task<BaseDto> GetByIdAsync(int Id)
        {
            var entity = await _repository.GetEntityByIDAsync(Id);
            return _mapper.Map<BaseDto>(entity);
        }

        public virtual async Task UpdateAsync(SaveDto vm, int Id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _repository.UpdateAsync(entity, Id);
        }
        public virtual async Task Delete(int Id)
        {
            var entity = await _repository.GetEntityByIDAsync(Id);
            await _repository.DeleteAsync(entity);
        }

        public async Task<SaveDto> GetByIdSaveDtoAsync(int Id)
        {
            var entity = await _repository.GetEntityByIDAsync(Id);
            return _mapper.Map<SaveDto>(entity);
        }

        public async Task<List<BaseDto>> FindAllAsync(Expression<Func<Entity, bool>> filter)
        {
            var query = await _repository.FindAllAsync(filter);
            return _mapper.Map<List<BaseDto>>(query);
        }
    }
}
