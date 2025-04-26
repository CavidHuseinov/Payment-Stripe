
using Ecommerce.Business.Helpers.DTOs.UserDto;
using FluentValidation;

namespace Ecommerce.Business.Helpers.Validators.UserValidator
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FullName).Matches(@"^[a-zA-Z]+$").WithMessage("Yalniz herflerden ibaret olsun")
                .NotEmpty().WithMessage("Adinizi tam daxil edin.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email hissesini bos buraxmayin.")
                .EmailAddress().WithMessage("Duzgun email formati daxil edin.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Istifadeci adini tam daxil edin.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Sifre hissesi bos olmasin")
                .Matches(@"[a-z]").WithMessage("Sifrede en azi 1 eded kicik herf olmalidir")
                .Matches(@"[A-Z]").WithMessage("Sifrede en azi 1 eded boyuk herf olmalidir")
                .Matches(@"[0-9]").WithMessage("Sifrede en azi 1 eded reqem olmalidir");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Sifreler beraber deyil");
        }
    }
}
