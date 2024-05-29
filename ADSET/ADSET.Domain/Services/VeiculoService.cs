using ADSET.Domain.DTOs.Request;
using ADSET.Domain.DTOs.Response;
using ADSET.Domain.Entities;
using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.Services;

namespace ADSET.Domain.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModeloService _modeloService;

        public VeiculoService(IUnitOfWork unitOfWork, IModeloService modeloService)
        {
            _modeloService = modeloService;
            _unitOfWork = unitOfWork;
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

        public async Task<bool> DeleteAsync(Guid id)
        {
            var veiculo = await GetByIdAsync(id);

            if (veiculo == null)
                throw new Exception("Erro ao inserir o veiculo");

            _unitOfWork.VeiculoRepository.Delete(veiculo);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<Veiculo> GetByIdAsync(Guid id)
        {
            var modelo = await _unitOfWork.VeiculoRepository.GetById(id);

            if (modelo == null)
                throw new Exception($"Veiculo com o ID: {id} não foi encontrado");

            return modelo;
        }

        public VeiculoPaginatedResponse GetListAsync(FilterPaginationRequest request)
        {
            var response = new VeiculoPaginatedResponse();

            response.QtdPerPage = request.QtdPerPage;
            response.PaginaAtual = request.PaginaAtual;
            response.TotalDados = _unitOfWork.VeiculoRepository
                .Filter(request)
                .ToList()
                .Count();

            var query = _unitOfWork.VeiculoRepository.Filter(request);

            if ((request.OrderByAsc != null && request.OrderByAsc.Count > 0) || (request.OrderByDesc != null && request.OrderByDesc.Count > 0))
                query = _unitOfWork.VeiculoRepository.OrdeningQuery(query, request.OrderByAsc, request.OrderByDesc);

            response.Dados = query
                .Skip((request.PaginaAtual - 1) * request.QtdPerPage)
                .Take(request.QtdPerPage)
                .ToList();

            return response;
        }

        public async Task<Veiculo> UpdateAsync(Veiculo veiculo, List<Guid>? opcionais)
        {
            var veiculoOld = await _unitOfWork.VeiculoRepository.GetByIdAsync(veiculo.Id);
            var veiculoOpcionais = await _unitOfWork.VeiculoRepository.GetVeiculoOpcionalList(veiculo.Id);

            if (veiculoOld == null)
                throw new Exception("Erro ao inserir o veiculo");

            var modelo = await _modeloService.GetById(veiculo.ModeloId);

            if (modelo == null)
                throw new Exception("Erro ao inserir o veiculo");

            if (!modelo.MarcaId.Equals(veiculo.MarcaId))
                throw new Exception("Erro ao inserir o veiculo");
            
            
            if (opcionais != null && opcionais.Count > 0)
            {
                if (veiculoOpcionais.Count() == 0)
                {
                    var veiculoOpcionaisCreate = opcionais.Select(o => new VeiculoOpcional(veiculo.Id, o)).ToList();
                    await _unitOfWork.VeiculoRepository.CreateVeiculoOpcionalList(veiculoOpcionaisCreate);
                }
                else
                {
                    var veiculoOpcionaisCreate = opcionais.Where(o => !veiculoOpcionais.Where(vo => vo.OpcionalId == o).Any())
                        .Select(o => new VeiculoOpcional(veiculoOld.Id, o)).ToList();

                    if (veiculoOpcionaisCreate.Count > 0)
                        await _unitOfWork.VeiculoRepository.CreateVeiculoOpcionalList(veiculoOpcionaisCreate);

                    var veiculoOpcionaisDelete = veiculoOpcionais.Where(vo => !opcionais.Where(o => vo.OpcionalId == o).Any()).Select(vo =>
                    {
                        vo.Delete();
                        return vo;
                    }).ToList();

                    if(veiculoOpcionaisDelete.Count > 0)
                        _unitOfWork.VeiculoRepository.UpdateVeiculoOpcionalList(veiculoOpcionaisDelete);
                }
            }
            else
            {
                if (veiculoOpcionais.Count() > 0)
                {
                    var veiculoOpcionaisDelete = veiculoOpcionais.Select(vo => { vo.Delete(); return vo; } ).ToList();
                    _unitOfWork.VeiculoRepository.UpdateVeiculoOpcionalList(veiculoOpcionaisDelete);
                }
            }

            veiculoOld.UpdateVeiculo(veiculo);

            var response = _unitOfWork.VeiculoRepository.Update(veiculoOld);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public async Task<List<string>> GetAllColors()
        {
            return await _unitOfWork.VeiculoRepository
                .GetAllColorsQuery();
        }

        public VeiculoCountResponse GetCount()
        {
            return _unitOfWork.VeiculoRepository.GetCount();
        }

        public async Task<Veiculo> UpdateHaveFotoAsync(Veiculo veiculo, bool haveFoto)
        {
            veiculo.UpdateHaveFoto(haveFoto);

            var response = _unitOfWork.VeiculoRepository.Update(veiculo);

            await _unitOfWork.CommitAsync();

            return response;
        }

        public List<Veiculo> GetAllIds(List<Guid> ids)
        {
            return _unitOfWork.VeiculoRepository
                .GetQuery()
                .Where(v => ids.Contains(v.Id))
                .ToList();
        }
    }
}
