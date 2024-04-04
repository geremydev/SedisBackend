using System.Linq.Expressions;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity, int Id);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetEntityByIDAsync(int Id);
        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAllWithIncludeAsync(List<string> properties);
    }
}
