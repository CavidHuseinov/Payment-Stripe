
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForImages;
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForVideos;

namespace Ecommerce.Business.Services.Interfaces
{
    public interface ICloudFlareImageService
    {
        Task<ImageUrlDto> UploadFileAsync(CreateImageUploadDto fileUploadDto);
    }
}
