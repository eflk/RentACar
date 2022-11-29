using Bussiness.Abstract;
using Bussiness.Constants;
using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public abstract class ManagerBase<T> : IService<T>
         where T : class, IEntity, new()
    {
        IEntityRepository<T> _dal;
        protected ManagerBase(IEntityRepository<T> dal)
        {
            _dal = dal;
        }

        public virtual IResult Add(T entity)
        {
            try
            {
                _dal.Add(entity);
                return new SuccessResult(Messages.RecordAddedSuccessfully);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.SystemError);
            }
        }

        public virtual IResult Delete(T entity)
        {
            try
            {
                _dal.Delete(entity);
                return new SuccessResult(Messages.RecordDeletedSuccessfully);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.SystemError);
            }
        }

        public virtual IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                var result = _dal.GetAll(filter);
                if (result.Count == 0)
                    return new ErrorDataResult<List<T>>(result);

                return new SuccessDataResult<List<T>>(result);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<T>>(Messages.SystemError);
            }
        }

        public virtual IDataResult<T> GetById(int id)
        {
            try
            {
                var result = _dal.Get(e => e.Id == id);
                if (result == null)
                    return new ErrorDataResult<T>(Messages.RecordNotFound);
                
                return new SuccessDataResult<T>(result);
            }
            catch (Exception)
            {

                return new ErrorDataResult<T>(Messages.SystemError);
            }
        }

        public virtual IResult Update(T entity)
        {
            try
            {
                _dal.Update(entity);
                return new SuccessResult(Messages.RecordUpdatedSuccessfully);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.SystemError);
            }
        }
    }
}
