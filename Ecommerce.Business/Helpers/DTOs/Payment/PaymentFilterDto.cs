
namespace Ecommerce.Business.Helpers.DTOs.Payment
{
    public record PaymentFilterDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public string PaymentMethod { get; set; }
        public bool? Is3DSecure { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
