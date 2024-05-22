using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdSetDesafio.Domain.Common.DTOs
{
    public class FiltroPaginacaoConsultarVeiculoDTO : PaginacaoBasicoDTO
    {
        public string Search { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<int> SearchStatusId { get; set; }

    }
}
