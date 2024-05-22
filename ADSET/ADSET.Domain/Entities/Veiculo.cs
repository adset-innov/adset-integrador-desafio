using System.Diagnostics.CodeAnalysis;

namespace ADSET.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public Veiculo()
        {}

        [SetsRequiredMembers]
        public Veiculo(Guid marcaId, Guid modeloId, int ano, string placa, string cor, decimal preco)
        {
            this.MarcaId = marcaId;
            this.ModeloId = modeloId;
            this.Ano = ano;
            this.Placa = placa;
            this.Cor = cor;
            this.Preco = preco;
            this.Add();
        }

        public required Guid MarcaId { get; set; }
        public required Guid ModeloId { get; set; }
        public required int Ano { get; set; }
        public required string Placa { get; set; }
        public int Km { get; set; }
        public required string Cor { get; set; }
        public required decimal Preco { get; set; }
        public bool HaveFoto { get; set; }

        public Marca? Marca { get; set; }
        public Modelo? Modelo { get; set; }

        public virtual ICollection<Foto>? Fotos { get; set; }
        public virtual ICollection<VeiculoOpcional>? VeiculoOpcionais { get; set; }
        public virtual ICollection<Pacote>? Pacotes { get; set; }

        public void UpdateVeiculo(Veiculo veiculo)
        {
            this.MarcaId = veiculo.MarcaId;
            this.ModeloId = veiculo.ModeloId;
            this.Ano = veiculo.Ano;
            this.Placa = veiculo.Placa;
            this.Km = veiculo.Km;
            this.Cor = veiculo.Cor;
            this.Preco = veiculo.Preco;
            this.HaveFoto = veiculo.HaveFoto;

            this.DateUpdated = DateTime.Now;
        }

        public void ModificarFoto(bool haveFoto)
        {
            this.HaveFoto = haveFoto;
        }
    }
}
