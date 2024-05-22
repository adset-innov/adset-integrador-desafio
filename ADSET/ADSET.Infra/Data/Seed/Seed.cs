using ADSET.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ADSET.Infra.Data.Seed
{
    public static class Seed
    {
        public static ModelBuilder CriarSeed(this ModelBuilder modelBuilder)
        {
            var opcionais = OpcionalSeed.CreateSeed();
            var marcas = MarcaSeed.CreateSeed();

            var modelos = ModeloSeed.CreateSeedFiat(marcas[0]);
            modelos.AddRange(ModeloSeed.CreateSeedFord(marcas[1]));
            modelos.AddRange(ModeloSeed.CreateSeedGMC(marcas[2]));
            modelos.AddRange(ModeloSeed.CreateSeedToyota(marcas[3]));

            var veiculos = new VeiculoSeed(modelos, opcionais);
            
            modelBuilder.Entity<Opcional>().HasData(opcionais);
            modelBuilder.Entity<Marca>().HasData(marcas);
            modelBuilder.Entity<Modelo>().HasData(modelos);
            modelBuilder.Entity<Veiculo>().HasData(veiculos.CreateSeed());

            return modelBuilder;
        }
    }
}
