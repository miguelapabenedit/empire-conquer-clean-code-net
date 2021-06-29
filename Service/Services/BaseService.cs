using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity: EntityBase
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        
        public BaseService(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        ///<inheritdoc cref="IBaseService{TEntity}"/>
        public async virtual Task<TEntity> CreateAsync(TEntity value, string userName)
        {
            value.CreatedBy = userName;
            value.CreatedDate = DateTime.UtcNow;
            value.UpdatedBy = userName;
            value.UpdatedDate = DateTime.UtcNow;

            var entity = await _repository.AddAsync(value).ConfigureAwait(false);

            await _unitOfWork.SaveAsync().ConfigureAwait(false);

            return entity;
        }

        ///<inheritdoc cref="IBaseService{TEntity}"/>
        public virtual async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id).ConfigureAwait(false);
            await _unitOfWork.SaveAsync().ConfigureAwait(false);
        }

        ///<inheritdoc cref="IBaseService{TEntity}"/>
        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _repository.GetAsync().ConfigureAwait(false);
        }

        ///<inheritdoc cref="IBaseService{TEntity}"/>
        public virtual async Task<TEntity> GetAsync(long id)
        {
            return await _repository.GetAsync(id).ConfigureAwait(false);
        }

        ///<inheritdoc cref="IBaseService{TEntity}"/>
        public virtual async Task<TEntity> UpdateAsync(long id, TEntity value, string userName)
        {
            value.UpdatedBy = userName;
            value.UpdatedDate = DateTime.UtcNow;
            value.Id = id;
            
            var entity = await _repository.Update(value).ConfigureAwait(false);

            await _unitOfWork.SaveAsync().ConfigureAwait(false);

            return entity;
        }
    }
}
