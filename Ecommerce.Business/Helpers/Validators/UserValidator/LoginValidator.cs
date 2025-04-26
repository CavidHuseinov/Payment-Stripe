
using Ecommerce.Business.Helpers.DTOs.UserDto;
using FluentValidation;

namespace Ecommerce.Business.Helpers.Validators.UserValidator
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserNameOrEmail).NotEmpty().WithMessage("Email ve ya username'nizi daxil edin");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Sifrenizi daxil edin");
        }
    }
}
