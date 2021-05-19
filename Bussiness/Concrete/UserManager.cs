using Bussiness.Abstract;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Bussiness.Concrete
{
    public class UserManager : ManagerBase<User>, IUserService
    {
        public UserManager(IUserDal userDal) : base(userDal)
        {
        }

        [ValidationAspect(typeof(UserValidator))]
        public override IResult Add(User entity)
        {
            return base.Add(entity);
        }

        [ValidationAspect(typeof(UserValidator))]
        public override IResult Update(User entity)
        {
            return base.Update(entity);
        }

    }
}
