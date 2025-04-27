
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForImages;
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForVideos;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface ICloudFlareVideoService
    {
        Task<VideoUrlDto> UploadFileAsync(CreateVideoUploadDto fileUploadDto);
    }
}
