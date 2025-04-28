using Ecommerce.Business.Helpers.DTOs.Cart;
using Ecommerce.Business.Services.Implementations;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.WebAPI.Controllers.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebAPI.Controllers
{
    public class CartController:ApiController
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetByUser()
        {
                var cartDtos = await _service.GetByUser();
                return Ok(cartDtos);  
        }
    }
}
