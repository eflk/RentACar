using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName).MinimumLength(2);

            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName).MinimumLength(2);

            RuleFor(u => u.Password).NotNull();
            RuleFor(u => u.Password).MinimumLength(4);

        }
    }
}
