
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForImages;
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForVideos;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface IAWSVideoService
    {
        Task<VideoUrlDto> UploadFileAsync(CreateVideoUploadDto fileUploadDto);
    }
}
