
using Ecommerce.Business.Helpers.DTOs.Payment;
using FluentValidation;

namespace Ecommerce.Business.Helpers.Validators.Payment
{
    public class CreatePaymentDtoValidator : AbstractValidator<CreatePaymentDto>
    {
        public CreatePaymentDtoValidator()
        {
            RuleFor(x => x.CardId)
                .NotEmpty().WithMessage("Kart ID tələb olunur.");

            RuleFor(x => x.TotalPrice)
                .GreaterThan(0.01f).WithMessage("Məbləğ 0.01-dən böyük olmalıdır.")
                .LessThanOrEqualTo(float.MaxValue).WithMessage("Məbləğ icazə verilən maksimum dəyəri keçir.");

            RuleFor(x => x.PaymentToken)
                .NotEmpty().WithMessage("Ödəniş tokeni tələb olunur.")
                .Length(10, 100).WithMessage("Ödəniş tokeni 10 ilə 100 simvol arasında olmalıdır.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Ödəniş metodu tələb olunur.")
                .Must(method => method == "card").WithMessage("Ödəniş metodu yalnız 'card' ola bilər.");

            RuleFor(x => x.CardHolderName)
                .NotEmpty().WithMessage("Kart sahibi adı tələb olunur.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Kart sahibi adı yalnız hərf və boşluqdan ibarət ola bilər.")
                .Length(2, 50).WithMessage("Kart sahibi adı 2 ilə 50 simvol arasında olmalıdır.");
        }
    }
}
