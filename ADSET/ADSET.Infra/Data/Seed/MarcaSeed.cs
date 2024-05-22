using ADSET.Domain.Entities;

namespace ADSET.Infra.Data.Seed
{
    public class MarcaSeed
    {
        public static List<Marca> CreateSeed()
        {
            return new List<Marca> 
            {
                new Marca("Fiat"),
                new Marca("Ford"),
                new Marca("GMC/Chevrolet"),
                new Marca("Toyota")
            };
        }
    }
}
