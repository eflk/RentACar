using Bussiness.Abstract;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Bussiness.Concrete
{
    public class CustomerManager : ManagerBase<Customer>, ICustomerService
    {
        public CustomerManager(ICustomerDal customerDal) : base(customerDal)
        {
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public override IResult Add(Customer entity)
        {
            return base.Add(entity);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public override IResult Update(Customer entity)
        {
            return base.Update(entity);
        }
    }
}
