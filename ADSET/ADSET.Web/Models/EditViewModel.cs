using ADSET.Application.DTOs.Responses;
using ADSET.Web.DTOs.Responses;

namespace ADSET.Web.Models
{
    public class EditViewModel
    {
        public List<DTOs.Responses.MarcaResponse> Marcas { get; set; }
        public List<CorResponse> Cores { get; set; }
        public List<DTOs.Responses.OpcionalResponse> Opcionais { get; set; }
        public VeiculoResponse Veiculo { get; set; }

    }
}
