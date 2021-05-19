using Bussiness.Abstract;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Bussiness.Concrete
{
    public class ColorManager : ManagerBase<Color>, IColorService
    {
        public ColorManager(IColorDal colorDal) : base(colorDal)
        {
        }

        [ValidationAspect(typeof(ColorValidator))]
        public override IResult Add(Color entity)
        {
            return base.Add(entity);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public override IResult Update(Color entity)
        {
            return base.Update(entity);
        }

    }
}
