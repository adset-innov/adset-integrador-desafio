using AdSet.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace AdSet.Dados.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Veiculo> Veiculos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
