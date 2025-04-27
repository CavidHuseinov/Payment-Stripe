
using Ecommerce.Core.Entities.Common;

namespace Ecommerce.DAL.Repositories.Interfaces
{
    public interface ICommandRepo<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
