using ADSET.Domain.DTOs.Request;
using ADSET.Domain.DTOs.Response;

namespace ADSET.Domain.Interfaces.ExternalServices
{
    public interface IAwsS3ExternalService
    {
        Task DeleteFileAsync(string nome);
        Task<List<S3ObjectResponse>> GetAllFilesAsync(string prefix);
        Task<List<S3ObjectResponse>> GetFiltredFilesAsync(string prefix, List<string> nameFiles);
        Task UpdateFilesToS3Bucket(List<VeiculoFotoRequest> request);
    }
}
