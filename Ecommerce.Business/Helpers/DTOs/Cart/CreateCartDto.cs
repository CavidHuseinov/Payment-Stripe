
using Ecommerce.Business.Helpers.DTOs.CartItem;

namespace Ecommerce.Business.Helpers.DTOs.Cart
{
    public record CreateCartDto
    {
        public ICollection<Guid>? CartItemIds { get; set; }
    }
}
