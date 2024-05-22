namespace ADSET.Domain.Entities
{
    public class Foto : BaseEntity
    {
        public required string Caminho { get; set; }
        public required Guid VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
    }
}
