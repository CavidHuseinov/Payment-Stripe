
using Ecommerce.Business.Helpers.DTOs.CartItem;
using Ecommerce.Business.Helpers.DTOs.Common;

namespace Ecommerce.Business.Helpers.DTOs.Cart
{
    public record CartDto:BaseDto
    {
        public ICollection<CartItemDto>? CartItems { get; set; }
    }
}
