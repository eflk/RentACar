using Core.Entities;
using Entities.DTOs;
using System;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public FileDto ImageFile { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
