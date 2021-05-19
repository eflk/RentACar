using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotNull();
            RuleFor(r => r.CarId).GreaterThan(0);

            RuleFor(r => r.CustomerId).NotNull();
            RuleFor(r => r.CustomerId).GreaterThan(0);

            RuleFor(r => r.RentDate).NotNull();
            RuleFor(r => r.RentDate.Date).GreaterThanOrEqualTo(DateTime.Today);

            RuleFor(r => r.ReturnDate).Null().When(r => r.Id == 0);
        }
    }
}
