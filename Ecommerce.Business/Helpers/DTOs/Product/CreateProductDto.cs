
using Ecommerce.Core.ValueObjects;

namespace Ecommerce.Business.Helpers.DTOs.Product
{
    public record CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public byte? Discount { get; set; }
        public string? ImgUrl { get; set; }
    }
}
