using ADSET.Application.DTOs.Enums;

namespace ADSET.Application.DTOs.Responses
{
    public class VeiculoResponse
    {
        public string? NomeMarca { get; set; }
        public string? NomeModelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public int Km { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public bool HaveFoto { get; set; }
        public int CountFoto { get; set; }
        public List<TipoPacote>? Pacotes { get; set; }
        public List<string>? Opcionais { get; set; }
    }
}
