using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;

namespace SedisBackend.Infrastructure.Persistence.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected SedisContext RepositoryContext;

    public RepositoryBase(SedisContext repositoryContext)
        => RepositoryContext = repositoryContext;

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
          RepositoryContext.Set<T>()
            .AsNoTracking() :
          RepositoryContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
    bool trackChanges) =>
        !trackChanges ?
          RepositoryContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
          RepositoryContext.Set<T>()
            .Where(expression);

    public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

    public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

    public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
}
