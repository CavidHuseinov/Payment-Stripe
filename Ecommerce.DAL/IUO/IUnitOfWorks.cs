
namespace Ecommerce.DAL.IUO
{
    public interface IUnitOfWorks
    {
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
