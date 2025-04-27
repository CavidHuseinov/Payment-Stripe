
using AutoMapper;
using Ecommerce.Business.Helpers.DTOs.Product;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.IUO;
using Ecommerce.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Business.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _command;
        private readonly IQueryRepo<Product> _query;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorks _work;

        public ProductService(IMapper mapper, IQueryRepo<Product> query, IProductRepo command, IUnitOfWorks work)
        {
            _mapper = mapper;
            _query = query;
            _command = command;
            _work = work;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
           var product = _mapper.Map<Product>(dto);
           var newProduct = await _command.CreateAsync(product);
           await _work.SaveChangesAsync();
           return _mapper.Map<ProductDto>(newProduct);
        }


        public async Task DeleteAsync(Guid id)
        {
            var product = await _query.GetByIdAsync(id);
            if (product == null) throw new ArgumentNullException("Mehsul tapilmadi");
            await _command.DeleteAsync(product);
            await _work.SaveChangesAsync();
        }

        public async Task<ICollection<ProductDto>> GetAllAsync()
        {
            var products = await _query.GetAllAsync().ToListAsync();
            return _mapper.Map<ICollection<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var productId = await _query.GetByIdAsync(id);
            if (productId == null) throw new ArgumentNullException("Mehsul tapilmadi");
            return _mapper.Map<ProductDto>(productId);
        }
    }
}
