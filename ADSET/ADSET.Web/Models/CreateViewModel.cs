using ADSET.Web.DTOs.Responses;

namespace ADSET.Web.Models
{
    public class CreateViewModel
    {
        public List<MarcaResponse> Marcas { get; set; }
        public List<CorResponse> Cores { get; set; }
        public List<OpcionalResponse> Opcionais { get; set; }
    }
}
