
using Ecommerce.Core.Entities.Common;
using Ecommerce.Core.ValueObjects;

namespace Ecommerce.Core.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ushort Price { get; set; }
        public byte? Discount { get; set; }
        public FinalPriceVO FinalPrice =>new FinalPriceVO(Discount,Price);
        // imgurl 
    }
}
