﻿using AutoMapper;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain;
using System.Linq.Expressions;

namespace SedisBackend.Core.Application.Services.Base
{
    public class GenericService<SaveDto, BaseDto, Entity> : IGenericService<SaveDto, BaseDto, Entity>
            where SaveDto : class
            where BaseDto : class
            where Entity : class, IBaseEntity
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> repository, ILoggerManager logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }
        public virtual async Task<BaseDto> AddAsync(SaveDto vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            //Recordar que el profesor la devolvía para atrás la entidad
            entity = await _repository.AddAsync(entity);
            var baseDto = _mapper.Map<BaseDto>(entity);
            return baseDto;
        }

        public virtual async Task<List<BaseDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var newList = _mapper.Map<List<BaseDto>>(list);
            //Recordar revisar que devuelva los que su delete sea false.
            return newList;
        }

        public virtual async Task<BaseDto> GetByIdAsync(Guid Id)
        {
            var entity = await _repository.GetEntityByIDAsync(Id);
            return _mapper.Map<BaseDto>(entity);
        }

        public virtual async Task UpdateAsync(SaveDto vm, Guid Id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _repository.UpdateAsync(entity, Id);
        }
        public virtual async Task Delete(Guid Id)
        {
            var entity = await _repository.GetEntityByIDAsync(Id);
            await _repository.DeleteAsync(entity);
        }

        public virtual async Task<SaveDto> GetByIdSaveDtoAsync(Guid Id)
        {
            var entity = await _repository.GetEntityByIDAsync(Id);
            return _mapper.Map<SaveDto>(entity);
        }

        public virtual async Task<List<BaseDto>> FindAllAsync(Expression<Func<Entity, bool>> filter)
        {
            var query = await _repository.FindAllAsync(filter);
            return _mapper.Map<List<BaseDto>>(query);
        }

        public virtual async Task<List<BaseDto>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = await _repository.GetAllWithIncludeAsync(properties);
            return _mapper.Map<List<BaseDto>>(query);
        }
    }
}
