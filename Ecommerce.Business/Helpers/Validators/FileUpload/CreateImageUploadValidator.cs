
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForImages;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Business.Helpers.Validators.FileUpload
{
    public class CreateImageUploadValidator : AbstractValidator<CreateImageUploadDto>
    {
        public CreateImageUploadValidator()
        {
            RuleFor(x => x.File)
                 .NotNull().WithMessage("The image must be uploaded.")
                 .Must(x => x.Length <= 3 * 1024 * 1024).WithMessage("The maximum allowed image size is 3MB. Please upload a valid image.")
                 .Must(x => IsValidImage(x)).WithMessage("Invalid image format. Supported formats: .jpeg, .jpg, .png, .svg, .bmp, .webp, .heif, .tiff, .gif");
        }

        private bool IsValidImage(IFormFile file)
        {
            if (file == null) return false;

            var validMimeTypes = new List<string>
    {
        "image/jpeg", "image/png", "image/svg+xml", "image/bmp", "image/webp", "image/heif", "image/tiff", "image/gif", "image/svg"
    };

            return validMimeTypes.Contains(file.ContentType.ToLower());
        }
    }
}
