using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class CarManagementContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=adset;Integrated Security=True;Encrypt=False");
        }
    }

}