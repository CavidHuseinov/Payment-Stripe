namespace Ecommerce.Business.Helpers.DTOs.Payment
{
    public record PaymentResponseDto
    {
        public bool Success { get; set; }
        public string PaymentId { get; set; }
        public bool Requires3DSecure { get; set; }
        public string RedirectUrl { get; set; }
        public string ClientSecret { get; set; }
        public string ErrorMessage { get; set; }
    }
}
