using System.Collections.Generic;

namespace AdSetDesafio.Domain.Common.DTOs
{
    public class DataTablesFiltro : PaginacaoBasicoDTO
    {
        public DataTablesFiltro()
        {
            Status = new List<string>();
            CentroCustos = new List<string>();
            CentroCustoLetras = new List<string>();
        }
        
        public string value { get; set; }

        public bool regex { get; set; }

        public string Descricao { get; set; }

        public List<string> Status { get; set; }

        public List<string> CentroCustos { get; set; }

        public List<string> CentroCustoLetras { get; set; }
    }
}