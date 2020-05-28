using System;
using Domain.Entities.Abs;
using Domain.Interfaces;

namespace Service.Validators
{
    public abstract class BaseValidator<TEntity> : IValidator<TEntity>
        where TEntity : class, IEntity
    {
        public abstract ValidatorReturn InsertValidation(TEntity entity);

        public abstract ValidatorReturn UpdateValidation(TEntity entity);        
    }
}
