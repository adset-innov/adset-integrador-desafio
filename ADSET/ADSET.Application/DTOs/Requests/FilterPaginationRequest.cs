using ADSET.Application.DTOs.Enums;
using ADSET.Application.Validators;
using FluentValidation;

namespace ADSET.Application.DTOs.Request
{
    public class FilterPaginationRequest
    {
        public FilterPaginationRequest()
        {}

        public FilterPaginationRequest(int paginaAtual, int qtdPerPage)
        {
            this.PaginaAtual = paginaAtual;
            this.QtdPerPage = qtdPerPage;
        }

        public string? Placa { get; set; }
        public Guid? MarcaId { get; set; }
        public Guid? ModeloId { get; set; }
        public int? AnoMin { get; set; }
        public int? AnoMax { get; set; }
        public decimal? Preco { get; set; }
        public bool? Foto { get; set; }
        public string? Cor { get; set; }

        public List<Ordenacao>? OrderByAsc { get; set; }
        public List<Ordenacao>? OrderByDesc { get; set; }

        public int PaginaAtual { get; set; }
        public int QtdPerPage { get; set; }


        public void Validate()
        {
            FilterPaginationRequestValitador validator = new();

            validator.ValidateAndThrow(this);
        }
    }
}
