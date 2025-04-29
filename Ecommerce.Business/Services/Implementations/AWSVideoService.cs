
using Amazon.S3;
using Amazon.S3.Transfer;
using Ecommerce.Business.Helpers.DTOs.FileUpload.ForVideos;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Business.Services.Implementations
{
    public class AWSVideoService : Interfaces.IAWSVideoService
    {
        private readonly AmazonS3Client _client;
        private readonly IConfiguration _config;

        public AWSVideoService(IConfiguration config)
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


        public async Task<VideoUrlDto> UploadFileAsync(CreateVideoUploadDto fileUploadDto)
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

            var videoUrl = $"{_config["CloudFlare:EndPointUrl"]}/{_config["CloudFlare:BucketName"]}/{fileName}";

            return new VideoUrlDto
            {
                VideoUrl = videoUrl
            };
        }
    }
}
