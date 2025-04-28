
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Context;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.DAL.Repositories.Implementations
{
    public class CartRepo : CommandRepo<Cart>, ICartRepo
    {
        public CartRepo(EcommerceDbContext context) : base(context)
        {
        }
    }
}
