namespace ADSET.Domain.Entities
{
    public class VeiculoOpcional : BaseEntity
    {
        public VeiculoOpcional()
        { }

        public VeiculoOpcional(Guid veiculoId, Guid opcionalId)
        {
            this.VeiculoId = veiculoId;
            this.OpcionalId = opcionalId;

            this.Add();
        }

        public Guid VeiculoId { get; set; }
        public Guid OpcionalId { get; set; }

        public Veiculo? Veiculo { get; set; }
        public Opcional? Opcional { get; set; }
    }
}
