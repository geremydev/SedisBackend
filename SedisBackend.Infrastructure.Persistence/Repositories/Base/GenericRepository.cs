using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly SedisContext _context;
        private readonly DbSet<TEntity> _entities;
        public GenericRepository(SedisContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        public virtual async Task DeleteAsync(TEntity entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.AnyAsync(filter);
        }

        public virtual async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.Where(filter).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetEntityByIDAsync(string Id)
        {
            return await _entities.FindAsync(Id);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity, string Id)
        {
            var entry = await _context.Set<TEntity>().FindAsync(Id);
            _context.Entry(entry).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
