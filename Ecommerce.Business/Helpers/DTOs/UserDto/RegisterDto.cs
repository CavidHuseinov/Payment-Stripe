
namespace Ecommerce.Business.Helpers.DTOs.UserDto
{
    public record RegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword {  get; set; }
    }
}
