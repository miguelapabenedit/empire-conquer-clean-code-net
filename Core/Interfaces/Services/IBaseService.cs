using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Gets a list of entity async.
        /// </summary>
        /// <returns>IEnumerable of entity.</returns>
        Task<IEnumerable<T>> GetAsync();
        
        /// <summary>
        /// Gets an entity by id async.
        /// </summary>
        /// <returns>Entity.</returns>
        /// <param name="Id">Id</param>
        Task<T> GetAsync(long Id);

        /// <summary>
        /// Creates an entity async.
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="value">entity</param>
        Task<T> CreateAsync(T value, string userName);

        /// <summary>
        /// updates an entity async.
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="userName">userName</param>
        /// <param name="value">entity</param>
        Task<T> UpdateAsync(long Id, T value, string userName);

        /// <summary>
        /// Deletes an entity by id async.
        /// </summary>
        /// <param name="Id"></param>
        Task DeleteAsync(long Id);
    }
}
