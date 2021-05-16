using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Bussiness.Concrete
{
    public class CustomerManager : ManagerBase<Customer>, ICustomerService
    {
        public CustomerManager(ICustomerDal customerDal) : base(customerDal)
        {
        }
    }
}
