using ADSET.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ADSET.Infra.Data.Seed
{
    public static class Seed
    {
        public static ModelBuilder CriarSeed(this ModelBuilder modelBuilder)
        {
            var opcionais = OpcionalSeed.CreateSeed();
            var modelos = ModeloSeed.CreateSeedFiat();
            modelos.AddRange(ModeloSeed.CreateSeedToyota());
            modelos.AddRange(ModeloSeed.CreateSeedFord());
            modelos.AddRange(ModeloSeed.CreateSeedGMC());
            modelos.AddRange(ModeloSeed.CreateSeedToyota());

            var veiculos = new VeiculoSeed(modelos, opcionais);
            
            modelBuilder.Entity<Opcional>().HasData(opcionais);
            modelBuilder.Entity<Modelo>().HasData(modelos);
            modelBuilder.Entity<Veiculo>().HasData(veiculos.CreateSeed());

            return modelBuilder;
        }
    }
}
