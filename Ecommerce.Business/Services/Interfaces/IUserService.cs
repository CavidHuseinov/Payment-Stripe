
using Ecommerce.Business.Helpers.DTOs.UserDto;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterDto register);
        Task<TokenDto> LoginAsync(LoginDto login);
    }
}
