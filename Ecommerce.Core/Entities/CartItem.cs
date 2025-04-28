
using Ecommerce.Core.Entities.Common;
using Ecommerce.Core.Entities.Identity;

namespace Ecommerce.Core.Entities
{
    public class CartItem:BaseEntity
    {
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public Cart? Cart { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
