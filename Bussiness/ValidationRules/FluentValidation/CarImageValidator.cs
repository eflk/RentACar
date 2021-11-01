using Bussiness.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(ci => ci.CarId).GreaterThan(0);
            RuleFor(ci => ci.ImageFile.FileExtension).Must(CheckIfExtensionAllowed).When(ci=> ci.ImageFile != null).WithMessage(Messages.IncorrectFileExtension);
            RuleFor(ci => ci.ImageFile.FileContent).NotNull().When(ci => ci.ImageFile != null);
            RuleFor(ci => ci.ImageFile.FileContent).NotEmpty().When(ci => ci.ImageFile != null);
            RuleFor(ci => ci.ImageFile.FileContent).Must(CheckIfBase64IsValid).When(ci => ci.ImageFile != null).WithMessage(Messages.IncorrectFileContent);
            
        }

        private bool CheckIfExtensionAllowed(string arg)
        {
            List<string> allowedExtensions = new List<string>() { "jpg", "jpeg", "png"};
            return allowedExtensions.Contains(arg);
        }

        private bool CheckIfBase64IsValid(string arg)
        {
            Span<byte> buffer = new Span<byte>(new byte[arg.Length]);
            return Convert.TryFromBase64String(arg, buffer, out int _);
        }
    }
}
