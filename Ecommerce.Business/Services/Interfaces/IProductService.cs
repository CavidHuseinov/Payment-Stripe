
using Ecommerce.Business.Helpers.DTOs.Product;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task DeleteAsync(Guid id);
    }
}
