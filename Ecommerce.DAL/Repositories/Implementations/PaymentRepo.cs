
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Context;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.DAL.Repositories.Implementations
{
    public class PaymentRepo : CommandRepo<Payment>, IPaymentRepo
    {
        public PaymentRepo(EcommerceDbContext context) : base(context)
        {
        }
    }
}
