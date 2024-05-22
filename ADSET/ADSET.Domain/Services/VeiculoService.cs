using ADSET.Domain.DTOs.Request;
using ADSET.Domain.DTOs.Response;
using ADSET.Domain.Entities;
using ADSET.Domain.Enums;
using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.Services;

namespace ADSET.Domain.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModeloService _modeloService;
        private readonly IOpcionalService _opcionalService;

        public VeiculoService(IUnitOfWork unitOfWork, IModeloService modeloService, IOpcionalService opcionalService)
        {
            _modeloService = modeloService;
            _unitOfWork = unitOfWork;
            _opcionalService = opcionalService;
        }


        public async Task<Veiculo> CreateAsync(Veiculo veiculo, List<Guid>? opcionais)
        {
            var modelo = await _modeloService.GetById(veiculo.ModeloId);

            if (modelo == null)
                throw new Exception("Erro ao inserir o veiculo");

            if(!modelo.MarcaId.Equals(veiculo.MarcaId))
                throw new Exception("Erro ao inserir o veiculo");

            if(opcionais != null && opcionais.Count > 0)
            {
                veiculo.VeiculoOpcionais = opcionais.Select(o => new VeiculoOpcional(o)).ToList();
            }

            var response = await _unitOfWork.VeiculoRepository.CreateAsync(veiculo);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Veiculo> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public VeiculoPaginatedResponse GetListAsync(FilterPaginationRequest request)
        {
            var response = new VeiculoPaginatedResponse();

            var query = _unitOfWork.VeiculoRepository.GetQuery();

            if (!String.IsNullOrEmpty(request.Placa))
                query.Where(v => v.Placa == request.Placa);
            if (!String.IsNullOrEmpty(request.Cor))
                query.Where(v => v.Cor == request.Cor);
            if (request.AnoMin != null || request.AnoMin < 2000)
                query.Where(v => v.Ano >= request.AnoMin);
            if (request.AnoMax != null || request.AnoMax < 2000)
                query.Where(v => v.Ano <= request.AnoMax);
            if (request.Foto != null)
                query.Where(v => v.HaveFoto == request.Foto);
            if (request.MarcaId != null)
                query.Where(v => v.MarcaId == request.MarcaId);
            if (request.ModeloId != null)
                query.Where(v => v.ModeloId == request.ModeloId);

            response.QtdPerPage = request.QtdPerPage;
            response.PaginaAtual = request.PaginaAtual;
            response.TotalDados = query.Count();

            if ((request.OrderByAsc != null && request.OrderByAsc.Count > 0) || (request.OrderByDesc != null && request.OrderByDesc.Count > 0))
                query = OrdeningQuery(query, request.OrderByAsc, request.OrderByDesc);

            response.Dados = query
                .Skip((request.PaginaAtual - 1) * request.QtdPerPage)
                .Take(request.QtdPerPage)
                .ToList();

            return response;
        }

        private IQueryable<Veiculo> OrdeningQuery(IQueryable<Veiculo> query, List<Ordenacao>? orderByAsc, List<Ordenacao>? orderByDesc)
        {
            if (orderByAsc != null && orderByAsc.Count > 0)
            {
                if (orderByAsc.Contains(Ordenacao.Ano))
                    query.OrderBy(v => v.Ano);
                if (orderByAsc.Contains(Ordenacao.Preco))
                    query.OrderBy(v => v.Preco);
                if (orderByAsc.Contains(Ordenacao.MarcaModelo))
                {
                    query.OrderBy(v => v.Marca.Nome);
                    query.OrderBy(v => v.Modelo.Nome);
                }
                if (orderByAsc.Contains(Ordenacao.Fotos))
                    query.OrderBy(v => v.Fotos.Count());
            }
            if (orderByDesc != null && orderByDesc.Count > 0)
            {
                if (orderByDesc.Contains(Ordenacao.Ano))
                    query.OrderByDescending(v => v.Ano);
                if (orderByDesc.Contains(Ordenacao.Preco))
                    query.OrderByDescending(v => v.Preco);
                if (orderByDesc.Contains(Ordenacao.MarcaModelo))
                {
                    query.OrderByDescending(v => v.Marca.Nome);
                    query.OrderByDescending(v => v.Modelo.Nome);
                }
                if (orderByDesc.Contains(Ordenacao.Fotos))
                    query.OrderByDescending(v => v.Fotos.Count());
            }
            
            return query;
        }

        public Task<Veiculo> UpdateAsync(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetAllColors()
        {
            return await _unitOfWork.VeiculoRepository
                .GetAllColorsQuery();
        }
    }
}
