using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace ADSET.Domain.Entities
{
    public class Opcional : BaseEntity
    {
        public Opcional()
        { }

        [SetsRequiredMembers]
        public Opcional(string nome)
        {
            this.Nome = nome;
            this.Add();
        }

        public required string Nome { get; set; }

        public virtual Collection<VeiculoOpcional>? VeiculoOpcionais { get; set; }
    }
}
