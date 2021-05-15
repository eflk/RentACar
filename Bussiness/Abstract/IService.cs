using Core.Entities;
using System.Collections.Generic;

namespace Bussiness.Abstract
{
    public interface IService<T> where T: class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
