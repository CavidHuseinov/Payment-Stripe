
namespace Ecommerce.Business.Helpers.DTOs.Payment
{
    public record PaymentResultDto
    {
        public bool IsSuccess { get; set; }
        public string PaymentIntentId { get; set; }
        public string Status { get; set; } // succeeded, requires_action, processing, canceled, vb.
        public bool RequiresAction { get; set; } // 3D Secure için
        public string ClientSecret { get; set; } // 3D Secure için gereken client secret
        public string NextActionUrl { get; set; } // 3D Secure yönlendirme URL'i
        public string ErrorMessage { get; set; }
    }
}
