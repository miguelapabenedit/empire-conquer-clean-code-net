using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<TEntity> GetAsync(long id);

        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> AddAsync(TEntity entity);

        Task DeleteAsync(long id);

        Task<TEntity> Update(TEntity entity);
    }
}
