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
        public string? Placa { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Opcional { get; set; }
        public int? AnoMin{ get; set; }
        public int? AnoMax { get; set; }
        public int? Preco { get; set; }
        public int? Fotos { get; set; }
        public string? Cor { get; set; }
    }
}
