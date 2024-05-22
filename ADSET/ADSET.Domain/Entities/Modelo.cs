using System.Diagnostics.CodeAnalysis;

namespace ADSET.Domain.Entities
{
    public class Modelo : BaseEntity
    {
        public Modelo()
        {}

        [SetsRequiredMembers]
        public Modelo(string nome, Marca marca)
        {
            this.Nome = nome;
            this.Marca = marca;
            this.MarcaId = marca.Id;
        }

        public required string Nome { get; set; }
        public required Guid MarcaId { get; set; }
        public Marca? Marca { get; set; }

        public virtual ICollection<Veiculo>? Veiculos { get; set; }

        public void UpdateVeiculo(Modelo modelo)
        {
            this.Nome = modelo.Nome;
            this.MarcaId = modelo.MarcaId;

            this.DateUpdated = DateTime.Now;
        }
    }
}