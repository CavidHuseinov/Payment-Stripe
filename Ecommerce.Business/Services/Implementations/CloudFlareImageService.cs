
using Amazon.S3;
using Amazon.S3.Transfer;
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForImages;
using Ecommerce.Business.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Business.Services.Implementations
{
    public class CloudFlareImageService : ICloudFlareImageService
    {
        private readonly AmazonS3Client _client;
        private readonly IConfiguration _config;

        public CloudFlareImageService(IConfiguration config)
        {
            _config = config; 

            var s3Config = new AmazonS3Config
            {
                ServiceURL = _config["CloudFlare:EndPointUrl"],
                ForcePathStyle = true
            };

            _client = new AmazonS3Client(
                _config["CloudFlare:AccessKeyId"],
                _config["CloudFlare:SecretAccessKey"],
                s3Config);
        }
    

        public async Task<ImageUrlDto> UploadFileAsync(CreateImageUploadDto fileUploadDto)
        {
            var fileName = $"{fileUploadDto.FolderName}/{Guid.NewGuid()}_{fileUploadDto.File.FileName}";

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = fileUploadDto.File.OpenReadStream(),
                Key = fileName,
                BucketName = _config["CloudFlare:BucketName"]
            };

            var transferUtility = new TransferUtility(_client);
            await transferUtility.UploadAsync(uploadRequest);

            var imageUrl = $"{_config["CloudFlare:EndPointUrl"]}/{_config["CloudFlare:BucketName"]}/{fileName}";

            return new ImageUrlDto
            {
                ImgUrl = imageUrl
            };
        }
    }
}
