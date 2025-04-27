using Microsoft.AspNetCore.Http;

namespace Ecommerce.Business.Helpers.DTOs.FileUpload.ForImages
{
    public record CreateImageUploadDto
    {
        public IFormFile File { get; set; }
        public string FolderName { get; set; }
    }
}
