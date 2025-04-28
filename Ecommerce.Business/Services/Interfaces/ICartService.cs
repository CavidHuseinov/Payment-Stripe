
using Ecommerce.Business.Helpers.DTOs.Cart;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartDto> GetByUser();
        Task<CartDto> CreateAsync(CreateCartDto dto);
        Task<CartDto> GetByIdAsync(Guid id);
    }
}
