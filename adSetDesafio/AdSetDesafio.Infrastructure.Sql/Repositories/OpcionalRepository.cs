using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdSetDesafio.Domain.Common.DTOs;
using AdSetDesafio.Domain.Common.Enums;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Common.Repositories;
using System.Diagnostics;
using AdSetDesafio.Infrastructure.Extensions;

namespace AdSetDesafio.Infrastructure.Sql.Repositories
{
    public sealed class OpcionalRepository : RepositoryBase<Opcional, IOpcionalRepository>, IOpcionalRepository
    {
        public string GetDbType()
        {
            return Enum.DbType.SqlServer.ToString();
        }

        public OpcionalRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<Opcional> GetAsync(int id)
        {
            var db = GetDbContext();
            db.ChangeTracker.AutoDetectChangesEnabled = false;
            var result = await db.Opcionais.FindAsync(id);
            db.ChangeTracker.AutoDetectChangesEnabled = true;

            return result;
        }

        public async Task<IEnumerable<Opcional>> GetAllAsync(Expression<Func<Opcional, bool>> predicate)
        {
            var db = GetDbContext();
            var data = await db.Opcionais
                .AsNoTracking()
                .ToListAsync();

            return data;
        }

        public Task<int> SaveAsync(Opcional entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Opcional entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}