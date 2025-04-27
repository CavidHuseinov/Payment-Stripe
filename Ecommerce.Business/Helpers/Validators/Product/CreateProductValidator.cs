
using Ecommerce.Business.Helpers.DTOs.Product;
using FluentValidation;

namespace Ecommerce.Business.Helpers.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Mehsulunuza ad teyin edin");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Mehsul ucun aciqlama elave edin");
            RuleFor(x=>x.Price)
                .NotEmpty().WithMessage("Mehsulunuza qiymet teyin edin")
                .GreaterThan(0).WithMessage("Mehsulun qiymeti 0dan boyuk olmalidir");
            RuleFor(x => x.Discount)
                .GreaterThan((byte)0).WithMessage("Mehsul ucun endirim faizi 0dan boyuk olmalidir")
                .LessThanOrEqualTo((byte)100).WithMessage("Mehsul ucun endirim faizi 100 ve ya 100den kicik olmalidir");
        }
    }
}
