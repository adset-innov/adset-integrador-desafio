using CatalogoVeiculo.Dados.Entities;
using System.ComponentModel.DataAnnotations;

namespace CatalogoVeiculo.Web.Models
{
    public class CatalogoViewModel
    {

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
        public string? Km { get; set; } = string.Empty;

        public  List<Opcional>? Opcionais { get; set; } = new List<Opcional>();
                         
        public  List<Foto>? Fotos { get; set; } = new List<Foto>();

    }
}
