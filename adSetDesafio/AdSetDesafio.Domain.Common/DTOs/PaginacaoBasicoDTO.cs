namespace AdSetDesafio.Domain.Common.DTOs
{
    public class PaginacaoBasicoDTO
    {
        public PaginacaoBasicoDTO()
        {
            QuantidadePorPagina = 100;
        }

        public int Pagina { get; set; }

        public int QuantidadePorPagina { get; set; }
    }
}