using ADSET.Domain.Entities;
using ADSET.Infra.Data.Configurations;
using ADSET.Infra.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace ADSET.Infra.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos => Set<Veiculo>();
        public DbSet<Marca> Marcas => Set<Marca>();
        public DbSet<Modelo> Modelos => Set<Modelo>();
        public DbSet<Foto> Fotos => Set<Foto>();
        public DbSet<Opcional> Opcionais => Set<Opcional>();
        public DbSet<Pacote> Pacotes => Set<Pacote>();

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateCreated") == null || entry.Entity.GetType().GetProperty("DateUpdated") == null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DateCreated").CurrentValue = DateTime.Now;
                else if (entry.State == EntityState.Modified)
                    entry.Property("DateUpdated").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
            modelBuilder.ApplyConfiguration(new ModeloConfiguration());
            modelBuilder.ApplyConfiguration(new MarcaConfiguration());
            modelBuilder.ApplyConfiguration(new FotoConfiguration());
            modelBuilder.ApplyConfiguration(new OpcionalConfiguration());
            modelBuilder.ApplyConfiguration(new VeiculoOpcionalConfiguration());
            modelBuilder.ApplyConfiguration(new PacoteConfiguration());

            modelBuilder.CriarSeed();
        }
    }
}
