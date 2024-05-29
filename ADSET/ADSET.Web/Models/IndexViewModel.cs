using ADSET.Application.DTOs.Responses;
using ADSET.Web.DTOs.Responses;

namespace ADSET.Web.Models
{
    public class IndexViewModel
    {
        public VeiculoCountResponse QtdVeiculos { get; set; }
        public List<DTOs.Responses.MarcaResponse> Marcas { get; set; }
        public List<CorResponse> Cores { get; set; }
        public List<DTOs.Responses.OpcionalResponse> Opcionais { get; set; }
        public VeiculoPaginatedResponse Veiculos { get; set; }
    }
}
