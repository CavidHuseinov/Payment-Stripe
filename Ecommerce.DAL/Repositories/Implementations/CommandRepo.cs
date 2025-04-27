
using Ecommerce.Core.Entities.Common;
using Ecommerce.DAL.Context;
using Ecommerce.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL.Repositories.Implementations
{
    public class CommandRepo<TEntity> :ICommandRepo<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly EcommerceDbContext _context;

        public CommandRepo(EcommerceDbContext context)
        {
            _context = context;
        }
        private DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var existingEntity = await Table.FindAsync(entity.Id);
            if (existingEntity == null)
            {
                throw new Exception($"{entity} not found");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

        }
    }
}
