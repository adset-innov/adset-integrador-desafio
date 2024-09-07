using CatalogoVeiculo.Dados.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoVeiculo.Dados.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        DbSet<Veiculo> Veiculos { get; set; }
        DbSet<Opcional> Opcionais { get; set; }
        DbSet<Foto> Fotos { get; set; }
    }
}
