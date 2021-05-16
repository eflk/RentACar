using Bussiness.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;

namespace Bussiness.Concrete
{
    public class RentalManager : ManagerBase<Rental>, IRentalService
    {
        ICarService _carService;
        ICustomerService _customerService;
        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService) : base(rentalDal)
        {
            _carService = carService;
            _customerService = customerService;
        }

        public IResult RentACar(int carId, int customerId, DateTime rentDate)
        {
            var carResult = _carService.GetById(carId);
            if (!carResult.Success) return new ErrorResult(carResult.Message);

            var customerResult = _customerService.GetById(customerId);
            if (!customerResult.Success) return new ErrorResult(customerResult.Message);


            if (base.GetAll((Rental c) => !c.ReturnDate.HasValue).Data.Count > 0) return new ErrorResult("The car already rented");

            return base.Add(new Rental
            {
                CarId = carId,
                CustomerId = customerId,
                RentDate = rentDate
            });
        }

        public IResult DeliverACar(int rentalId, DateTime returnDate)
        {
            var rentalResult = base.GetById(rentalId);
            if (!rentalResult.Success) return new ErrorResult(rentalResult.Message);
            if (rentalResult.Data == null) return new ErrorResult("Incorrect rental id");
            if (!rentalResult.Data.ReturnDate.Equals(null)) return new ErrorResult("Already delivered");
            if (rentalResult.Data.RentDate.CompareTo(returnDate) > 0) return new ErrorResult("Deliver date cannot be earlier then rent date");
            rentalResult.Data.ReturnDate = returnDate;

            return base.Update(rentalResult.Data);
        }
    }
}