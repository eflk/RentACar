﻿using Core.Entities;

namespace Entities.DTOs
{
    public class CarInfoDto : IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }

    }
}