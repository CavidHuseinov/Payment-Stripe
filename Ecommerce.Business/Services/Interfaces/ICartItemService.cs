
using Ecommerce.Business.Helpers.DTOs.CartItem;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface ICartItemService
    {
        Task<CartItemDto> CreateAsync(CreateCartItemDto dto);
        Task<ICollection<CartItemDto>> GetAllAsync();
        Task<CartItemDto> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
