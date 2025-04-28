
namespace Ecommerce.Business.Helpers.DTOs.CartItem
{
    public record CreateCartItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
