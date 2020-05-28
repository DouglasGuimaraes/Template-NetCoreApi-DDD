using System;
using Domain.Entities.Abs;

namespace Domain.Interfaces
{
    public interface IValidator<T> where T : class, IEntity
    {
        ValidatorReturn InsertValidation(T entity);
        ValidatorReturn UpdateValidation(T entity);
    }
}
