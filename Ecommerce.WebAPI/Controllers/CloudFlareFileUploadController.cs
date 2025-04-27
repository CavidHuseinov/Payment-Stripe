using Ecommerce.Business.Helpers.DTOs.FileUpload.ForImages;
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForVideos;
using Ecommerce.Business.Services.Interfaces;
using Ecommerce.WebAPI.Controllers.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebAPI.Controllers
{
    public class CloudFlareFileUploadController:ApiController
    {
        private readonly ICloudFlareImageService _imgService;
        private readonly ICloudFlareVideoService _videoService;

        public CloudFlareFileUploadController(ICloudFlareImageService imgService, ICloudFlareVideoService videoService)
        {
            _imgService = imgService;
            _videoService = videoService;
        }
        [HttpPost("create-img")]
        public async Task<IActionResult> CreateImageFile(CreateImageUploadDto dto)
        {
            var img = await _imgService.UploadFileAsync(dto);
            return Ok(img);
        }
        [HttpPost("create-video")]
        public async Task<IActionResult> CreateVideoFile(CreateVideoUploadDto dto)
        {
            var video = await _videoService.UploadFileAsync(dto);
            return Ok(video);
        }
    }
}
