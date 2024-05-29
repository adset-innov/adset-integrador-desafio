namespace ADSET.Application.DTOs.Responses
{
    public class VeiculoPaginatedResponse
    {
        public List<VeiculoResponse> Dados { get; set; }
        public int QtdPerPage { get; set; }
        public int PaginaAtual { get; set; }
        public decimal? TotalPaginas { get; set; }
        public int TotalDados { get; set; }
    }
}
