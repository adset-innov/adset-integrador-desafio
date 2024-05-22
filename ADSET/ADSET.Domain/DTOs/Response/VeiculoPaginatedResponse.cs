using ADSET.Domain.Entities;

namespace ADSET.Domain.DTOs.Response
{
    public class VeiculoPaginatedResponse
    {
        public List<Veiculo> Dados { get; set; }
        public int QtdPerPage { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalDados { get; set; }
    }
}
