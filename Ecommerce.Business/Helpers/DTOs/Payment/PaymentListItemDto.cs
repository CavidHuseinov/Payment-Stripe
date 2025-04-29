
namespace Ecommerce.Business.Helpers.DTOs.Payment
{
    public record PaymentListItemDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CardHolderName { get; set; }
        public string LastFourDigits { get; set; }
    }
}
