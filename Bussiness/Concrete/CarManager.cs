using Bussiness.Abstract;
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

        public override IResult Add(Car car)
        {
            if (car.Description.Length < 10) throw new System.Exception("Açıklama minimum 10 hane olmalı");
            return base.Add(car);
        }
       
        public List<CarInfoDto> GetCarInfos()
        {
            return _carDal.GetCarInfos();
        }
    }
}
