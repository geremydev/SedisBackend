using System.Linq.Expressions;

namespace SedisBackend.Core.Application.Interfaces.Services.Base
{
    public interface IGenericService<SaveDto, BaseDto, Model>
        where SaveDto : class
        where BaseDto : class
        where Model : class
    {
        public Task<BaseDto> AddAsync(SaveDto vm);
        public Task<List<BaseDto>> GetAllAsync();
        public Task<BaseDto> GetByIdAsync(Guid Id);
        public Task<SaveDto> GetByIdSaveDtoAsync(Guid Id);
        public Task UpdateAsync(SaveDto vm, Guid Id);
        public Task Delete(Guid Id);
        Task<List<BaseDto>> FindAllAsync(Expression<Func<Model, bool>> filter);
        Task<List<BaseDto>> GetAllWithIncludeAsync(List<string> properties);
    }
}