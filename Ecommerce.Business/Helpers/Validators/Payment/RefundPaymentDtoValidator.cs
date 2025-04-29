
using Ecommerce.Business.Helpers.DTOs.Payment;
using FluentValidation;

namespace Ecommerce.Business.Helpers.Validators.Payment
{
    public class RefundPaymentDtoValidator : AbstractValidator<RefundPaymentDto>
    {
        public RefundPaymentDtoValidator()
        {
            RuleFor(x => x.PaymentId)
                .NotEmpty().WithMessage("Ödəniş ID tələb olunur.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).When(x => x.Amount.HasValue)
                .WithMessage("Geri qaytarma məbləği göstərilibsə, 0-dan böyük olmalıdır.");

            RuleFor(x => x.Reason)
                .MaximumLength(500).WithMessage("Geri qaytarma səbəbi 500 simvoldan çox ola bilməz.")
                .When(x => !string.IsNullOrEmpty(x.Reason));
        }
    }
}
