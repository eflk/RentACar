using Bussiness.Abstract;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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

        [ValidationAspect(typeof(RentalRentACarValidator))]
        public IResult RentACar(Rental rental)
        {
            var carResult = _carService.GetById(rental.CarId);
            if (!carResult.Success) return new ErrorResult(carResult.Message);

            var customerResult = _customerService.GetById(rental.CustomerId);
            if (!customerResult.Success) return new ErrorResult(customerResult.Message);

            if (base.GetAll((Rental c) => !c.ReturnDate.HasValue).Data.Count > 0) return new ErrorResult("The car already rented");

            return base.Add(rental);
        }

        [ValidationAspect(typeof(RentalReturnACarValidator))]
        public IResult ReturnACar(Rental rental)
        {
            var rentalResult = base.GetById(rental.Id);
            if (!rentalResult.Success) return new ErrorResult(rentalResult.Message);
            if (rentalResult.Data == null) return new ErrorResult("Incorrect rental id");
            if (!rentalResult.Data.ReturnDate.Equals(null)) return new ErrorResult("Already returned");
            if (rentalResult.Data.RentDate.CompareTo(rental.ReturnDate) > 0) return new ErrorResult("Return date cannot be earlier then rent date");
            rentalResult.Data.ReturnDate = rental.ReturnDate;

            return base.Update(rentalResult.Data);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public override IResult Add(Rental entity)
        {
            return base.Add(entity);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public override IResult Update(Rental entity)
        {
            return base.Update(entity);
        }
    }
}