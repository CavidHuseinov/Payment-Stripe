using Ecommerce.Business.Helpers.DTOs.Product;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.WebAPI.Controllers.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var productId = await _service.GetByIdAsync(id);
            return Ok(productId);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var productAll = await _service.GetAllAsync();
            return Ok(productAll);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateProductDto dto)
        {
            var product = await _service.CreateAsync(dto);
            return Ok(product);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
