
using Ecommerce.Business.Helpers.DTOs.Common;

namespace Ecommerce.Business.Helpers.DTOs.UserDto
{
    public record UserDto
    {
        public string Id {  get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
