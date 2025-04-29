
using Ecommerce.Business.Helpers.DTOs.Payment;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResultDto> ProcessPaymentAsync(CreatePaymentDto paymentDto);
        Task<PaymentResultDto> ConfirmPaymentAsync(string paymentIntentId);
    }
}
