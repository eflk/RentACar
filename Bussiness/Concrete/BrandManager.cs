using Bussiness.Abstract;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Bussiness.Concrete
{
    public class BrandManager : ManagerBase<Brand>, IBrandService
    {
        public BrandManager(IBrandDal brandDal) : base(brandDal)
        {
        }

        [ValidationAspect(typeof(BrandValidator))]
        public override IResult Add(Brand entity)
        {
            return base.Add(entity);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public override IResult Update(Brand entity)
        {
            return base.Update(entity);
        }
    }
}
