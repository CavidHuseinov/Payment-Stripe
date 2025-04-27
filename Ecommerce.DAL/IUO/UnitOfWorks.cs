

using Ecommerce.DAL.Context;

namespace Ecommerce.DAL.IUO
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly EcommerceDbContext _context;

        public UnitOfWorks(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            return await _context.SaveChangesAsync(cancellation);
        }
    }
}
