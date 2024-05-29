using ADSET.Domain.DTOs.Request;
using ADSET.Domain.DTOs.Response;
using ADSET.Domain.Interfaces.ExternalServices;
using ADSET.Domain.Options;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;

namespace ADSET.Infra.ExternalServices
{
    public class AwsS3ExternalService : IAwsS3ExternalService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly AwsOptions _awsOptions;

        public AwsS3ExternalService(IAmazonS3 s3Client, IOptions<AwsOptions> awsOptions)
        {
            _s3Client = s3Client;
            _awsOptions = awsOptions.Value;
        }

        public async Task UpdateFilesToS3Bucket(List<VeiculoFotoRequest> request)
        {
            try
            {
                var bucketExists = await _s3Client.DoesS3BucketExistAsync(_awsOptions.BucketName);

                if (!bucketExists) throw new Exception($"Bucket {_awsOptions.BucketName} does not exist.");

                foreach (var file in request)
                {
                    await PutFileInS3Async(file);
                }   

                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<S3ObjectResponse>> GetFiltredFilesAsync(string prefix, List<string> nameFiles)
        {
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(_awsOptions.BucketName);
            if (!bucketExists) throw new Exception($"Bucket {_awsOptions.BucketName} does not exist.");

            var request = new ListObjectsV2Request()
            {
                BucketName = _awsOptions.BucketName,
                Prefix = prefix
            };

            var result = await _s3Client.ListObjectsV2Async(request);
            var s3Objects = result.S3Objects.Where(s => nameFiles.Contains(s.Key)).Select(s =>
            {
                var urlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = _awsOptions.BucketName,
                    Key = s.Key,
                    Expires = DateTime.UtcNow.AddMonths(2)
                };

                return new S3ObjectResponse()
                {
                    Name = s.Key.ToString(),
                    PresignedUrl = _s3Client.GetPreSignedURL(urlRequest),
                };
            }).ToList();

            return s3Objects;
        }

        public async Task<List<S3ObjectResponse>> GetAllFilesAsync(string prefix)
        {
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(_awsOptions.BucketName);
            if (!bucketExists) throw new Exception($"Bucket {_awsOptions.BucketName} does not exist.");

            var request = new ListObjectsV2Request()
            {
                BucketName = _awsOptions.BucketName,
                Prefix = prefix
            };

            var result = await _s3Client.ListObjectsV2Async(request);
            var s3Objects = result.S3Objects.Select(s =>
            {
                var urlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = _awsOptions.BucketName,
                    Key = s.Key,
                    Expires = DateTime.UtcNow.AddMonths(2)
                };

                return new S3ObjectResponse()
                {
                    Name = s.Key.ToString(),
                    PresignedUrl = _s3Client.GetPreSignedURL(urlRequest),
                };
            }).ToList();

            return s3Objects;
        }

        private async Task PutFileInS3Async(VeiculoFotoRequest request)
        {
            try
            {
                var putObject = new PutObjectRequest()
                {
                    BucketName = _awsOptions.BucketName,
                    Key = $"{request.VeiculoId.ToString()}/{request.Nome}",
                    InputStream = request.Stream
                };

                putObject.Metadata.Add("Content-Type", request.ContentType);

                var response = await _s3Client.PutObjectAsync(putObject);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    return;
                else
                    throw new Exception($"{response.HttpStatusCode} no arquivo {request.Nome}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao realizar o upload do arquivo {request.Nome}", ex);
            }
        }


        public async Task DeleteFileAsync(string nome)
        {
            try
            {
                var bucketExists = await _s3Client.DoesS3BucketExistAsync(_awsOptions.BucketName);
                if (!bucketExists) throw new Exception($"Bucket {_awsOptions.BucketName} does not exist.");

                var response = await _s3Client.DeleteObjectAsync(_awsOptions.BucketName, nome);

                if (response.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
                    return;
                else
                    throw new Exception($"{response.HttpStatusCode} no arquivo {nome}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao realizar o upload do arquivo {nome}", ex);
            }
        }
    }
}
