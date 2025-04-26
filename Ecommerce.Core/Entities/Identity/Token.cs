
using Ecommerce.Core.Entities.Common;

namespace Ecommerce.Core.Entities.Identity
{
    public class Token:BaseEntity
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
    }
}
