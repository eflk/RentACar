using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Bussiness.Concrete
{
    public class ColorManager : ManagerBase<Color>, IColorService
    {
        public ColorManager(IColorDal colorDal) : base(colorDal)
        {
        }

     
    }
}
