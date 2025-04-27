
namespace Ecommerce.Core.ValueObjects
{
    public class FinalPriceVO
    {
        public float FinalPrice {  get; set; }

        public FinalPriceVO(byte? discount , float price)
        {
            if (discount == null)
            {
                FinalPrice = price;
            }
            else
            {
                FinalPrice =(price - ((price * discount.Value) / 100));
            }
        }
    }
}
