using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Infrastructure.Interfaces;
using AdSetDesafio.Infrastructure.Sql.DbContexts.Config;

namespace AdSetDesafio.Infrastructure.Sql.DbContexts
{
    public class SQLDbContext : DbContext, IDbContext
    {
        private readonly ConfigSQL config;
        private IDbConnection sqlConnection;

        public Enum.DbType DbType => Enum.DbType.SqlServer;
        
        public DbSet<Veiculo> Veiculos { get; set; }
        
        public DbSet<FotoVeiculo> FotosVeiculos { get; set; }

        public DbSet<Opcional> Opcionais { get; set; }

        public SQLDbContext(ConfigSQL config) : base()
        {
            this.config = config;
        }

        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(config.ConnectionString,
                 sqlOptions =>
                 {
                     sqlOptions.EnableRetryOnFailure(
                     maxRetryCount: 10,
                     maxRetryDelay: TimeSpan.FromSeconds(30),
                     errorNumbersToAdd: null);
                 });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SQLDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbConnection GetConnection()
        {
            return sqlConnection = new SqlConnection(config.ConnectionString);
        }
    }
}