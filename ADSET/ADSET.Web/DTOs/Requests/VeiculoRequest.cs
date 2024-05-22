namespace ADSET.Web.DTOs.Requests
{
    public class VeiculoRequest
    {
        public required Guid MarcaId { get; set; }
        public required Guid ModeloId { get; set; }
        public required int Ano { get; set; }
        public required string Placa { get; set; }
        public int Km { get; set; }
        public required string Cor { get; set; }
        public required decimal Preco { get; set; }
    }
}
