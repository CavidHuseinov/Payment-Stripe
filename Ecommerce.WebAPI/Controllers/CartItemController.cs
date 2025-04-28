using Ecommerce.Business.Helpers.DTOs.CartItem;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.WebAPI.Controllers.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebAPI.Controllers
{
    public class CartItemController:ApiController
    {
        private readonly ICartItemService _service;

        public CartItemController(ICartItemService service)
        {
            _service = service;
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var cart = await _service.GetByIdAsync(id);
            return Ok(cart);
        }
        [HttpGet("all-cart-item")]
        public async Task<IActionResult> GetByUser()
        {
            var cart = await _service.GetAllAsync();
            return Ok(cart);
        }
        [HttpPost("create-cartItem")]
        public async Task<IActionResult> CreateCartItemAsync(CreateCartItemDto dto)
        {
            var cart = await _service.CreateAsync(dto);
            return Ok(cart);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
