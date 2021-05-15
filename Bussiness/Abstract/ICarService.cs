using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Bussiness.Abstract
{
    public interface ICarService : IService<Car>
    {
        List<CarInfoDto> GetCarInfos();
    }
}
