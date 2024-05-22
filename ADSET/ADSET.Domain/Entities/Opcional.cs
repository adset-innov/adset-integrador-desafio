using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace ADSET.Domain.Entities
{
    public class Opcional : BaseEntity
    {
        public Opcional()
        { }

        [SetsRequiredMembers]
        public Opcional(string name)
        {
            this.Name = name;
            this.Add();
        }

        public required string Name { get; set; }

        public virtual Collection<VeiculoOpcional>? VeiculoOpcionais { get; set; }
    }
}
