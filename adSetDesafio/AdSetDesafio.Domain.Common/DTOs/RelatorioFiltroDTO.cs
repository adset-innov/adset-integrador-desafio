using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdSetDesafio.Domain.Common.DTOs
{
    public class RelatorioFiltroDTO<T>
    {
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}
