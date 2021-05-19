using Entities.Concrete;
using FluentValidation;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {

            RuleFor(c => c.BrandId).NotNull();
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).NotNull();
            RuleFor(c => c.ModelYear).GreaterThan(1995);

            // Must be at least 10 characters if not null.
            RuleFor(c => c.Description).MinimumLength(10).When(c=> !string.IsNullOrEmpty(c.Description)).WithMessage("Description length must be at least '10' characters.");

        }
    }
}
