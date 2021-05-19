using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Bussiness.Abstract
{
    public interface ICarService : IService<Car>
    {
        IDataResult<List<CarInfoDto>> GetCarInfos();
    }
}
