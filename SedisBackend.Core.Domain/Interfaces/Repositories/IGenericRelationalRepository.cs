namespace SedisBackend.Core.Domain.Interfaces.Repositories;
public interface IGenericRelationalRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllEntitiesAsync(bool trackChanges);
    Task<T> GetEntityAsync(Guid entityA, Guid entityB, bool trackChanges);
    void CreateEntity(T entity);
    void DeleteEntity(T entity);
}
