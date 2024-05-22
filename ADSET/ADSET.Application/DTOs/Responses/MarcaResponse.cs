namespace ADSET.Application.DTOs.Responses
{
    public class MarcaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<ModeloResponse>? Modelos { get; set; }
    }
}
