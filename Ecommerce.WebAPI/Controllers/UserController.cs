using Ecommerce.Business.Helpers.DTOs.UserDto;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.WebAPI.Controllers.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebAPI.Controllers
{
    public class UserController:ApiController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto dto)
        {
            await _service.RegisterAsync(dto);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromForm] LoginDto dto)
        {
            var token = await _service.LoginAsync(dto);
            return Ok(token);
        }
    }
}
