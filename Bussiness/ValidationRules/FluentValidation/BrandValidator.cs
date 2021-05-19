using Entities.Concrete;
using FluentValidation;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name).NotNull();
            //RuleFor(b => b.Name).MinimumLength(2).WithMessage("Brand name length must be at least '2'");
            RuleFor(b => b.Name).MinimumLength(2);
        }
    }
}
