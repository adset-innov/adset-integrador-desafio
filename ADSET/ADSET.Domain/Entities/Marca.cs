namespace ADSET.Domain.Entities
{
    public class Marca : BaseEntity
    {
        public required string Nome { get; set; }

        public void UpdateVeiculo(Marca marca)
        {
            this.Nome = marca.Nome;

            this.DateUpdated = DateTime.Now;
        }
    }
}