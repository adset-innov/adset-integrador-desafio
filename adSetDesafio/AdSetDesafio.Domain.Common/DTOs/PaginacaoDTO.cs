using System.Collections.Generic;

namespace AdSetDesafio.Domain.Common.DTOs
{
    public class PaginacaoDTO<TObject> : PaginacaoBasicoDTO
        where TObject : class
    {
        public int Total { get; set; }
        
        public ICollection<TObject> Dados { get; set; }
    }
}