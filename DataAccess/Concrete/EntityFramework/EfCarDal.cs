using Core.DataAccess.EntityFramework;
using Core.Utilities.FileSystem;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDBContext>, ICarDal
    {
        public List<CarInfoDto> GetCarInfos()
        {
            using (RentACarDBContext context = new RentACarDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarInfoDto {
                                 BrandName = b.Name,
                                 CarName = c.Id.ToString(),
                                 ColorName = cl.Name,
                                 DailyPrice = c.DailyPrice,
                                 CarImages = (from ci in context.CarImages
                                              where ci.CarId == c.Id
                                              select FileSystemOperations.GetFileFromPath(ci.ImagePath).Data
                                              ).ToList()
                             };
                return result.ToList();
            }
        }
    }
}
