using System.Diagnostics.CodeAnalysis;

namespace ADSET.Domain.Entities
{
    public class Foto : BaseEntity
    {
        public required string Caminho { get; set; }
        public required string Nome { get; set; }
        public required Guid VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }

        [SetsRequiredMembers]
        public Foto(string caminho, string nome, Guid veiculoId)
        {
            this.Caminho = caminho;
            this.Nome = nome;
            this.VeiculoId = veiculoId;

            this.Add();
        }
    }
}
