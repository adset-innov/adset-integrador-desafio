using ADSET.Application.DTOs.Response;
using ADSET.Web.DTOs.Responses;

namespace ADSET.Web.Models
{
    public class IndexViewModel
    {
        public CountVeiculosResponse QtdVeiculos { get; set; }
        public List<MarcaResponse> Marcas { get; set; }
        public List<CorResponse> Cores { get; set; }
        public List<OpcionalResponse> Opcionais { get; set; }
        public VeiculoPaginatedResponse Veiculos { get; set; }
    }
}
