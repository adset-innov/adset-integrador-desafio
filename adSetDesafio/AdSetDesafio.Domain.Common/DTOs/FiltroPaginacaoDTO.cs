namespace AdSetDesafio.Domain.Common.DTOs
{
    public class FiltroPaginacaoDTO : PaginacaoBasicoDTO
    {
        public string Filtro { get; set; } = "";

        public int? Id { get; set; }
    }
}