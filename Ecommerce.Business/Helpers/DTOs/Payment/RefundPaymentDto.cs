
namespace Ecommerce.Business.Helpers.DTOs.Payment
{
    public record RefundPaymentDto
    {
        public Guid PaymentId { get; set; }
        public decimal? Amount { get; set; } // null geri qaytarilma
        public string Reason { get; set; }
    }
}
