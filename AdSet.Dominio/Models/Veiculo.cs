using System.ComponentModel.DataAnnotations.Schema;

namespace AdSet.Dominio.Models
{
    [Table("cad_veiculos")]
    public class Veiculo
    {
        public Guid Id { get; set; }
        public string Marca { get; set; } = default!;
        public string Modelo { get; set; } = default!;
        public ushort Ano { get; set; }
        public string Placa { get; set; } = default!;
        public uint Km { get; set; }
        public string Cor { get; set; } = default!;
        public float Preco { get; set; }
        public virtual IList<Opcional> Opcionais { get; set; } = new List<Opcional>();
        public virtual IList<Foto> Fotos { get; set; } = new List<Foto>();
    }

    [Table("cad_opcionais")]
    public class Opcional
    {
        public Guid Id { get; set; }
        public bool? ArCondicionado { get; set; }
        public bool? Alarme { get; set; }
        public bool? AirBag { get; set; }
        public bool? FreioAbs { get; set; }
    }

    [Table("cad_fotos")]
    public class Foto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Imagem { get; set; } = default!;
    }

}
