﻿using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Bussiness.Concrete
{
    public class BrandManager : ManagerBase<Brand>, IBrandService
    {
        public BrandManager(IBrandDal brandDal) : base(brandDal)
        {
        }
    }
}
