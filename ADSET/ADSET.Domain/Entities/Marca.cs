using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ADSET.Domain.Entities
{
    public class Marca : BaseEntity
    {
        public Marca()
        { }

        [SetsRequiredMembers]
        public Marca(string nome)
        {
            this.Nome = nome;
            this.Add();
        }

        public required string Nome { get; set; }

        public virtual ICollection<Veiculo>? Veiculos { get; set; }
        public virtual ICollection<Modelo>? Modelos { get; set; }

        public void UpdateVeiculo(Marca marca)
        {
            this.Nome = marca.Nome;

            this.DateUpdated = DateTime.Now;
        }
    }
}