using Entities.Concrete;
using FluentValidation;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty();
        }
    }
}
