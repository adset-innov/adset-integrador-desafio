namespace ADSET.Domain.Entities
{
    public class Modelo : BaseEntity
    {
        public required string Nome { get; set; }
        public required Guid MarcaId { get; set; }
        public Marca? Marca { get; set; }


        public void UpdateVeiculo(Modelo modelo)
        {
            this.Nome = modelo.Nome;
            this.MarcaId = modelo.MarcaId;

            this.DateUpdated = DateTime.Now;
        }
    }
}