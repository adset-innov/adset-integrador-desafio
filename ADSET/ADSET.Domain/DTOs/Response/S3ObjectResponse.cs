namespace ADSET.Domain.DTOs.Response
{
    public class S3ObjectResponse
    {
        public string? Name { get; set; }
        public string? PresignedUrl { get; set; }
    }
}
