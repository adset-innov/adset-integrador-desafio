using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoVeiculo.Dados.Entities
{
    [Table("cad_opcionais")]
    public class Opcional
    {
        [Key]
        public Guid? Id { get; set; }
        public string? Descricao { get; set; } = string.Empty;
    }
}
