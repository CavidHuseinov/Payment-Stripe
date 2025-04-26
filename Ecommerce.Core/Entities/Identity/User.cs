
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Core.Entities.Identity
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
    }
}
