namespace ADSET.Domain.DTOs.Request
{
    public class UpdateFilesRequest
    {
        public Stream Stream { get; set; }
        public string Nome { get; set; }
        public string ContentType { get; set; }
        public Guid VeiculoId { get; set; }
    }
}
