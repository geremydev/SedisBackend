using System.Linq.Expressions;

namespace SedisBackend.Core.Application.Interfaces.Services.Base
{
    public interface IGenericService<SaveDto, BaseDto, Model>
        where SaveDto : class
        where BaseDto : class
        where Model : class
    {
        public Task<SaveDto> AddAsync(SaveDto vm);
        public Task<List<BaseDto>> GetAllAsync();
        public Task<BaseDto> GetByIdAsync(int Id);
        public Task<SaveDto> GetByIdSaveDtoAsync(int Id);
        public Task UpdateAsync(SaveDto vm, int Id);
        public Task Delete(int Id);
        Task<List<BaseDto>> FindAllAsync(Expression<Func<Model, bool>> filter);
        Task<List<BaseDto>> GetAllWithIncludeAsync(List<string> properties);
    }
}