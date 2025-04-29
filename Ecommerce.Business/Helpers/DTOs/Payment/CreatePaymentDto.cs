
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Business.Helpers.DTOs.Payment
{
    public record CreatePaymentDto
    {
        public Guid CardId { get; set; } 
        public float TotalPrice { get; set; } 
        public string PaymentToken { get; set; }
        public string PaymentMethod { get; set; } = "visa"; 
        public string CardHolderName { get; set; }
    }
}
