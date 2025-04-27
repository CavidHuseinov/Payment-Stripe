
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Context;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.DAL.Repositories.Implementations
{
    public class ProductRepo : CommandRepo<Product>, IProductRepo
    {
        public ProductRepo(EcommerceDbContext context) : base(context)
        {
        }
    }
}
