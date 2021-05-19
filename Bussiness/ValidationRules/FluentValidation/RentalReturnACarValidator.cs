using Entities.Concrete;
using FluentValidation;
using System;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class RentalReturnACarValidator : AbstractValidator<Rental>
    {
        public RentalReturnACarValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0);

            RuleFor(r => r.ReturnDate).NotNull();
            RuleFor(r => r.ReturnDate.Value.Date).GreaterThanOrEqualTo(DateTime.UtcNow.Date).When(r => r.ReturnDate.HasValue);

        }

    }
}
