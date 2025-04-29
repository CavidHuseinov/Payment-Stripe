
using Ecommerce.Business.Helpers.DTOs.Payment;
using FluentValidation;

namespace Ecommerce.Business.Helpers.Validators.Payment
{
    public class PaymentFilterDtoValidator : AbstractValidator<PaymentFilterDto>
    {
        public PaymentFilterDtoValidator()
        {
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate ?? DateTime.MaxValue)
                .When(x => x.StartDate.HasValue && x.EndDate.HasValue)
                .WithMessage("Başlanğıc tarixi bitiş tarixindən kiçik və ya bərabər olmalıdır.");

            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate ?? DateTime.MinValue)
                .When(x => x.StartDate.HasValue && x.EndDate.HasValue)
                .WithMessage("Bitiş tarixi başlanğıc tarixindən böyük və ya bərabər olmalıdır.");

            RuleFor(x => x.MinAmount)
                .GreaterThanOrEqualTo(0).When(x => x.MinAmount.HasValue)
                .WithMessage("Minimum məbləğ mənfi ola bilməz.");

            RuleFor(x => x.MaxAmount)
                .GreaterThanOrEqualTo(x => x.MinAmount ?? 0)
                .When(x => x.MaxAmount.HasValue && x.MinAmount.HasValue)
                .WithMessage("Maksimum məbləğ minimum məbləğdən böyük və ya bərabər olmalıdır.");

            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1).WithMessage("Səhifə nömrəsi ən azı 1 olmalıdır.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100).WithMessage("Səhifə ölçüsü 1 ilə 100 arasında olmalıdır.");

            RuleFor(x => x.Status)
                .Must(status => string.IsNullOrEmpty(status) || IsValidStatus(status))
                .WithMessage("Ödəniş statusu yanlışdır.");

            RuleFor(x => x.PaymentMethod)
                .Must(method => string.IsNullOrEmpty(method) || method == "card")
                .WithMessage("Ödəniş metodu göstərilibsə, yalnız 'card' ola bilər.");
        }

        private bool IsValidStatus(string status)
        {
            var validStatuses = new[] { "succeeded", "pending", "failed", "canceled" };
            return validStatuses.Contains(status.ToLower());
        }
    }
}
