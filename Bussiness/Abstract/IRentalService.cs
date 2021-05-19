using Core.Utilities.Results;
using Entities.Concrete;
using System;

namespace Bussiness.Abstract
{
    public interface IRentalService : IService<Rental>
    {
        IResult RentACar(Rental rental);
        IResult ReturnACar(Rental rental);
    }
}
