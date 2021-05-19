using Entities.Concrete;
using FluentValidation;
using System;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class RentalRentACarValidator : AbstractValidator<Rental>
    {
        public RentalRentACarValidator()
        {
            RuleFor(r => r.Id).Null();
            RuleFor(r => r.CarId).GreaterThan(0);
            RuleFor(r => r.CustomerId).GreaterThan(0);
            
            RuleFor(r => r.ReturnDate).Null();

            RuleFor(r => r.RentDate).NotNull();
            RuleFor(r => r.RentDate.Date).GreaterThanOrEqualTo(DateTime.UtcNow.Date);

        }

    }
}
