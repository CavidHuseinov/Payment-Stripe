
using Ecommerce.Core.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Core.Entities
{
    public class Payment:BaseEntity
    {
        public string StripePaymentIntentId { get; set; }
        public string Status { get; set; } 
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "Dollar";
        public string CardHolderName { get; set; }
        public string LastFourDigits { get; set; } 
        public string PaymentMethod { get; set; }
        public bool Is3DSecure { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        public string UserId { get; set; }
        public Guid CartId { get; set; }
    }
}
