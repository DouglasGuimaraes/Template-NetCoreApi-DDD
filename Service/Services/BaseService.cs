using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Service.Services
{
    public abstract class BaseService<TEntity, TRepository, TValidator> : IService<TEntity>
        where TEntity     : class, IEntity
        where TRepository : class, IRepository<TEntity>
        where TValidator  : class, IValidator<TEntity>
    {
        protected readonly TRepository repository;
        private readonly TValidator validator;

        public BaseService(TRepository repository, TValidator validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<TEntity> Delete(int id)
        {
            return await repository.Delete(id);
        }

        public async Task<TEntity> Get(int id)
        {
            return await repository.Get(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public List<TEntity> GetByFilter(Func<TEntity, bool> predicate)
        {
            return repository.GetByFilter(predicate);
        }

        public virtual async Task<TEntity> Post(TEntity entity)
        {
            var val = validator.InsertValidation(entity);
            if (val.Ok)
                return await repository.Add(entity);
            else
                throw new Exception(val.Message);
        }

        public virtual async Task<TEntity> Put(TEntity entity)
        {
            var val = validator.UpdateValidation(entity);
            if (val.Ok)
                return await repository.Update(entity);
            else
                throw new Exception(val.Message);
        }
    }
}
