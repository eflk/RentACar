using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarManager : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarManager()
        {
            _cars = new List<Car>
            {
                new Car(){ Id=1, BrandId=1, ColorId=1, DailyPrice=120, ModelYear=2021, Description="5213km de sağda ufak çizik var." },
                new Car(){ Id=2, BrandId=9, ColorId=1, DailyPrice=100, ModelYear=2021, Description="ww" },
                new Car(){ Id=3, BrandId=2, ColorId=5, DailyPrice=200, ModelYear=2021, Description="aa" },
                new Car(){ Id=4, BrandId=2, ColorId=2, DailyPrice=520, ModelYear=2021, Description="ss" },
                new Car(){ Id=5, BrandId=5, ColorId=6, DailyPrice=720, ModelYear=2021, Description="ll" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            if (carToDelete != null) _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            return filter != null ? _cars.SingleOrDefault(filter.Compile()) : null;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter != null ? _cars.Where(filter.Compile()).ToList() : _cars;
        }

        public List<CarInfoDto> GetCarInfos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            foreach (var from in car.GetType().GetProperties())
                foreach (var to in carToUpdate.GetType().GetProperties())
                    if(to.Name == from.Name && to.PropertyType == from.PropertyType)
                        to.SetValue(carToUpdate, from.GetValue(car));
        }
    }
}
