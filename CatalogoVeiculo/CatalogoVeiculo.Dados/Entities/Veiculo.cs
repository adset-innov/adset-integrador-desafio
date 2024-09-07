using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CatalogoVeiculo.Dados.Entities
{
    [Table("cad_veiculos")]
    public class Veiculo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Marca { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        [MaxLength(4)]
        public string Ano { get; set; } = string.Empty;

        [Required]
        [MaxLength(7)]
        public string Placa { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string Cor { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Preco { get; set; } = string.Empty;

        [MaxLength(20)]
        [AllowNull]
        public string? Km { get; set; } = string.Empty;

        [ForeignKey(nameof(OpcionalId))]
        [AllowNull]
        public Guid? OpcionalId{ get; set; } 
        public virtual List<Opcional>? Opcionais { get; set; } = new List<Opcional>();

        [ForeignKey(nameof(FotoId))]
        [AllowNull]
        public Guid? FotoId { get; set; }
        public virtual List<Foto>? Fotos { get; set; } = new List<Foto>();

    }
}
