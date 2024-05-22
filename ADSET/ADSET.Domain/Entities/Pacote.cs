using ADSET.Domain.Enums;

namespace ADSET.Domain.Entities
{
    public class Pacote : BaseEntity
    {
        public TipoPacote Tipo { get; set; }
        public Guid VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }
    }
}
