
namespace Ecommerce.Business.Helpers.DTOs.UserDto
{
    public record LoginDto
    {
        public string UserNameOrEmail {  get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
