using ADSET.Application.DTOs.Responses;

namespace ADSET.Application.DTOs.Response
{
    public class VeiculoPaginatedResponse
    {
        public List<VeiculoResponse> Dados { get; set; }
        public int QtdPerPage { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalDados { get; set; }
    }
}
