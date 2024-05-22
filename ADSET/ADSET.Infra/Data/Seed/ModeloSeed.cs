using ADSET.Domain.Entities;

namespace ADSET.Infra.Data.Seed
{
    public class ModeloSeed
    {
        public static List<Modelo> CreateSeedFord()
        {
            var marca = new Marca("Ford");
            return new List<Modelo>()
            {
                new("Ka", marca),
                new("Mustang", marca),
                new("Range", marca),
                new("Belina", marca),
                new("Del Rey", marca),
                new("Verona", marca),
                new("Pampa", marca)
            };
        }

        public static List<Modelo> CreateSeedFiat()
        {
            var marca = new Marca("Fiat");
            return new List<Modelo>()
            {
                new("Uno", marca),
                new("Toro", marca),
                new("147", marca),
                new("500", marca),
                new("Bravo", marca),
                new("Strada", marca),
                new("Marea", marca),
                new("Tempra", marca)
            };
        }

        public static List<Modelo> CreateSeedGMC()
        {
            var marca = new Marca("GMC/Chevrolet");
            return new List<Modelo>()
            {
                new("S10", marca),
                new("C10", marca),
                new("Camaro", marca),
                new("Blaze", marca),
                new("Agile", marca),
                new("Onix", marca),
                new("Silverado", marca),
                new("Caravan", marca)
            };
        }

        public static List<Modelo> CreateSeedToyota()
        {
            var marca = new Marca("Toyota");
            return new List<Modelo>()
            {
                new("Corolla", marca),
                new("Hilux", marca),
                new("SW4", marca),
                new("Etios", marca),
                new("Camry", marca),
                new("RAV4", marca),
                new("Supra", marca),
                new("Yaris", marca)
            };
        }
    }
}
