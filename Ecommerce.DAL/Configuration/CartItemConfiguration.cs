
using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DAL.Configuration
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Product)
                .WithMany(x=>x.CartItems)
                .HasForeignKey(x=>x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
