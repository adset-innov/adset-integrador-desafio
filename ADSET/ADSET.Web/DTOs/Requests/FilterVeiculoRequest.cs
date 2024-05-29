using ADSET.Application.DTOs.Requests;

namespace ADSET.Web.DTOs.Requests
{
    public class FilterVeiculoRequest
    {
        public FilterVeiculoRequest(string? placa, Guid? marca, Guid? modelo, int? anoMin, int? anoMax, string? preco, bool? foto, string? cor, Guid? opcional, int? paginaAtual = 1, int? qtdPerPage = 10)
        {
            Placa = placa ?? null;
            MarcaId = marca ?? null;
            ModeloId = modelo ?? null;
            AnoMin = anoMin ?? null;
            AnoMax = anoMax ?? null;
            Preco = preco ?? null;
            Foto = foto ?? null;
            Cor = cor ?? null;
            PaginaAtual = paginaAtual ?? 1;
            QtdPerPage = qtdPerPage ?? 10;
            OpcionalId = opcional;
        }

        public Guid? MarcaId { get; set; }
        public Guid? ModeloId { get; set; }
        public int? AnoMin { get; set; }
        public int? AnoMax { get; set; }
        public string? Placa { get; set; }
        public bool? Foto { get; set; }
        public string? Cor { get; set; }
        public string? Preco { get; set; }
        public int PaginaAtual { get; set; }
        public int QtdPerPage { get; set; }
        public Guid? OpcionalId { get; set; }

        public FilterPaginationRequest Mapping()
        {
            return new FilterPaginationRequest() 
            {
                MarcaId = MarcaId,
                ModeloId = ModeloId,
                AnoMin = AnoMin,
                AnoMax = AnoMax,
                Placa = Placa,
                Foto = Foto,
                Cor = Cor,
                Preco = Preco,
                OpcionalId = OpcionalId,
                PaginaAtual = PaginaAtual,
                QtdPerPage = QtdPerPage
            };
        }
    }
}
