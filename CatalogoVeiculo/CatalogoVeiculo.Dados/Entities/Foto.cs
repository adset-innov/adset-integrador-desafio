using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoVeiculo.Dados.Entities
{
    [Table("cad_fotos")]
    public class Foto
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; } = string.Empty;   
        public string Imagem { get; set; } = string.Empty;
    }
}
