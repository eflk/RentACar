using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bussiness.Abstract
{
    public interface IService<T> where T: class, IEntity, new()
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
        IDataResult<T> GetById(int id);
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
