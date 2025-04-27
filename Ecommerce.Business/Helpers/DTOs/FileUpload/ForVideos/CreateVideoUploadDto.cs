
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Business.Helpers.DTOs.FileUpload.ForVideos
{
    public record CreateVideoUploadDto
    {
        public IFormFile File { get; set; }
        public string FolderName { get; set; }
    }
}
