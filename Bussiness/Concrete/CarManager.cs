using Bussiness.Abstract;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Bussiness.Concrete
{
    public class CarManager : ManagerBase<Car>, ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal) : base(carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public override IResult Add(Car car)
        {
            return base.Add(car);
        }

        [ValidationAspect(typeof(CarValidator))]
        public override IResult Update(Car entity)
        {
            return base.Update(entity);
        }


        public IDataResult<List<CarInfoDto>> GetCarInfos()
        {
            return new SuccessDataResult<List<CarInfoDto>>(_carDal.GetCarInfos());
        }
    }
}
