
using Ecommerce.Core.Entities.Common;
using Ecommerce.Core.Entities.Identity;

namespace Ecommerce.Core.Entities
{
    public class Cart:BaseEntity
    {
        public ICollection<CartItem>? CartItems { get; set; }
        public string UserId { get; set; }
    }
}
