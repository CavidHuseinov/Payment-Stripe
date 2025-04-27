
using Ecommerce.Business.Helpers.DTOs.Common;
using Ecommerce.Core.ValueObjects;

namespace Ecommerce.Business.Helpers.DTOs.Product
{
    public record ProductDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public byte? Discount { get; set; }
        public float FinalPrice { get; }
        public string ImgUrl { get; set; }
    }
}
