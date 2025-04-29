
namespace Ecommerce.Business.Helpers.DTOs.Payment
{
    public record PaymentDetailDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CardHolderName { get; set; }
        public string LastFourDigits { get; set; }
        public string PaymentMethod { get; set; }
        public bool Is3DSecure { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string StripePaymentIntentId { get; set; }
    }
}
