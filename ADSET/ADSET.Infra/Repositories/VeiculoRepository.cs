using ADSET.Domain.DTOs.Request;
using ADSET.Domain.DTOs.Response;
using ADSET.Domain.Entities;
using ADSET.Domain.Enums;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Data;
using ADSET.Infra.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ADSET.Infra.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        private readonly SqlContext _context;

        public VeiculoRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

        public int CountQueryFilter(IQueryable<Veiculo> query)
        {
            return query.Count();
        }

        public async Task<List<string>> GetAllColorsQuery()
        {
            return await _context.Veiculos
                .Select(v => v.Cor)
                .Distinct()
                .ToListAsync();
        }

        public IQueryable<Veiculo> Filter(FilterPaginationRequest request)
        {
            return _context.Veiculos
                .Include(v => v.VeiculoOpcionais)
                    .ThenInclude(o => o.Opcional)
                .Include(v => v.Marca)
                .Include(v => v.Modelo)
                .Include(v => v.Fotos)
                .Include(v => v.Pacotes)
                .Where(v => v.IsActive)
                .Filter(!String.IsNullOrEmpty(request.Placa), v => v.Placa.Equals(request.Placa))
                .Filter(!String.IsNullOrEmpty(request.Cor), v => v.Cor.Equals(request.Cor))
                .Filter(request.AnoMin.HasValue, v => v.Ano >= request.AnoMin)
                .Filter(request.AnoMax.HasValue, v => v.Ano <= request.AnoMax)
                .Filter(request.Foto.HasValue, v => v.HaveFoto.Equals(request.Foto))
                .Filter(request.MarcaId.HasValue, v => v.MarcaId.Equals(request.MarcaId))
                .Filter(request.ModeloId.HasValue, v => v.ModeloId.Equals(request.ModeloId))
                .AsQueryable();
        }

        public IQueryable<Veiculo> OrdeningQuery(IQueryable<Veiculo> query, List<Ordenacao>? orderByAsc, List<Ordenacao>? orderByDesc)
        {

            if (orderByAsc != null && orderByAsc.Count > 0)
            {
                query
                    .OrderByAsc(orderByAsc.Contains(Ordenacao.Ano), v => v.Ano)
                    .OrderByAsc(orderByAsc.Contains(Ordenacao.Preco), v => v.Preco)
                    .OrderByAsc(orderByAsc.Contains(Ordenacao.MarcaModelo), v => v.Marca.Nome)
                    .OrderByAsc(orderByAsc.Contains(Ordenacao.MarcaModelo), v => v.Modelo.Nome)
                    .OrderByAsc(orderByAsc.Contains(Ordenacao.Fotos), v => v.Fotos.Count());
            }
            if (orderByDesc != null && orderByDesc.Count > 0)
            {
                query
                    .OrderByDesc(orderByDesc.Contains(Ordenacao.Ano), v => v.Ano)
                    .OrderByDesc(orderByDesc.Contains(Ordenacao.Preco), v => v.Preco)
                    .OrderByDesc(orderByDesc.Contains(Ordenacao.MarcaModelo), v => v.Marca.Nome)
                    .OrderByDesc(orderByDesc.Contains(Ordenacao.MarcaModelo), v => v.Modelo.Nome)
                    .OrderByDesc(orderByDesc.Contains(Ordenacao.Fotos), v => v.Fotos.Count());
            }

            return query;
        }

        public IQueryable<Veiculo> GetQuery()
        {
            return _context.Veiculos
                .Include(v => v.VeiculoOpcionais.Where(vo => vo.IsActive))
                    .ThenInclude(o => o.Opcional)
                .Include(v => v.Marca)
                .Include(v => v.Modelo)
                .Include(v => v.Fotos)
                .Include(v => v.Pacotes.Where(vo => vo.IsActive));
        }

        public VeiculoCountResponse GetCount()
        {
            var query = _context.Veiculos;
            return new VeiculoCountResponse()
            {
                TotalVeiculo = query.Where(v => v.IsActive).Count(),
                TotalVeiculoComFoto = query.Where(v => v.IsActive).Where(v => v.HaveFoto).Count(),
                TotalVeiculoSemFoto = query.Where(v => v.IsActive).Where(v => !v.HaveFoto).Count(),
            };
        }

        public async Task<Veiculo?> GetById(Guid id)
        {
            return await _context.Veiculos
                .AsNoTracking()
                .Include(v => v.VeiculoOpcionais.Where(vo => vo.IsActive))
                    .ThenInclude(o => o.Opcional)
                .Include(v => v.Marca)
                .Include(v => v.Modelo)
                .Include(v => v.Fotos)
                .Include(v => v.Pacotes.Where(vo => vo.IsActive))
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<VeiculoOpcional>> GetVeiculoOpcionalList(Guid veiculoId)
        {
            return await _context.VeiculoOpcionais
                .Where(vo => vo.IsActive && vo.VeiculoId == veiculoId)
                .ToListAsync();
        }


        public async Task CreateVeiculoOpcionalList(List<VeiculoOpcional> request)
        {
            await _context.VeiculoOpcionais.AddRangeAsync(request);
        }

        public void UpdateVeiculoOpcionalList(List<VeiculoOpcional> request)
        {
            _context.VeiculoOpcionais.UpdateRange(request);
        }
    }
}
