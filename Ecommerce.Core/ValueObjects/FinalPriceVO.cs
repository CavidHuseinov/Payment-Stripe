
namespace Ecommerce.Core.ValueObjects
{
    public class FinalPriceVO
    {
        public ushort FinalPrice {  get; set; }

        public FinalPriceVO(byte? discount , ushort price)
        {
            if (discount == null)
            {
                FinalPrice = price;
            }
            else
            {
                FinalPrice =(ushort)(price - ((price * discount.Value) / 100));
            }
        }
    }
}
