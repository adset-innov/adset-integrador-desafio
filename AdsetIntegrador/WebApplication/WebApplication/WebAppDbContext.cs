using Microsoft.EntityFrameworkCore;
using ClassLibrary;

namespace WebApplication
{
    public class WebAppDbContext : CarManagementContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base()
        {
        }

        // Adicione este construtor se você também precisa dos DbContextOptions
        // public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        // {
        // }
    }
}
