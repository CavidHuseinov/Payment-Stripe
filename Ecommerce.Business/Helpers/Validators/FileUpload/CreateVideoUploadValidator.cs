
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForVideos;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Business.Helpers.Validators.FileUpload
{
    public class CreateVideoUploadValidator : AbstractValidator<CreateVideoUploadDto>
    {
        public CreateVideoUploadValidator()
        {
            RuleFor(x => x.File)
                 .NotNull().WithMessage("The video must be uploaded.")
                 .Must(x => x.Length <= 50 * 1024 * 1024)
                 .WithMessage("The maximum allowed video size is 50MB. Please upload a valid video.")
                 .Must(x => IsValidVideo(x))
                 .WithMessage("Invalid video format. Supported formats: .mp4, .avi, .mkv, .webm, .mov, .flv, .3gp, .wmv");
        }

        private bool IsValidVideo(IFormFile file)
        {
            if (file == null) return false;

            var validMimeTypes = new HashSet<string>
            {
                "video/mp4",
                "video/x-msvideo",
                "video/x-matroska",
                "video/webm",
                "video/quicktime",
                "video/x-flv",
                "video/3gpp",
                "video/x-ms-wmv"
            };

            return validMimeTypes.Contains(file.ContentType.ToLower());
        }
    }
}
