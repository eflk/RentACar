using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Bussiness.Concrete
{
    public class UserManager : ManagerBase<User>, IUserService
    {
        public UserManager(IUserDal userDal) : base(userDal)
        {
        }
    }
}
