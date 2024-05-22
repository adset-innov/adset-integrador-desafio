using Microsoft.EntityFrameworkCore;
using ClassLibrary;

namespace AdSetDesafio
{
    public class WebAppDbContext : CarManagementContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base()
        {
        }
    }
}
