namespace SedisBackend.Core.Domain.Interfaces.Repositories;

public interface IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAllEntitiesAsync(bool trackChanges);
    Task<T> GetEntityAsync(Guid entityId, bool trackChanges);
    void CreateEntity(T entity);
    void DeleteEntity(T entity);
    void UpdateEntity(T entity);    
}
