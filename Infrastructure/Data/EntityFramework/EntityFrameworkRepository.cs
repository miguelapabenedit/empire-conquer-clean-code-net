using Microsoft.EntityFrameworkCore;
using Core.Interfaces.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityFramework
{
    public abstract class EntityFrameworkRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        protected TContext DBContext { get; private set; }

        public EntityFrameworkRepository(TContext context)
        {
            DBContext = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await DBContext.AddAsync<TEntity>(entity).ConfigureAwait(false);
            return entity;
        }

        public virtual async Task DeleteAsync(long id)
        {
            var entity = DBContext.Set<TEntity>().Find(id);

            await Task.FromResult(DBContext.Remove<TEntity>(entity)).ConfigureAwait(false);
        }

        public virtual async Task<TEntity> GetAsync(long id)
        {
            return await DBContext.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
        }

        public virtual async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = DBContext.Set<TEntity>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            DBContext.Update<TEntity>(entity);

            return await Task.FromResult(entity);
        }
    }
}
