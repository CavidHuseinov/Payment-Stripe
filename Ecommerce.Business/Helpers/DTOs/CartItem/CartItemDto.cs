
using Ecommerce.Business.Helpers.DTOs.Common;
using Ecommerce.Business.Helpers.DTOs.Product;

namespace Ecommerce.Business.Helpers.DTOs.CartItem
{
    public record CartItemDto:BaseDto
    {
        public ProductDto? Product { get; set; }
        public int Quantity { get; set; }
    }
}
