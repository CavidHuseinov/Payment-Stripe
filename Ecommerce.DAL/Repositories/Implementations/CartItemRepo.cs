
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Context;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.DAL.Repositories.Implementations
{
    public class CartItemRepo : CommandRepo<CartItem>, ICartItemRepo
    {
        public CartItemRepo(EcommerceDbContext context) : base(context)
        {
        }
    }
}
