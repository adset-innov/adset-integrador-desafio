using AdSetDesafio.Domain.Common.DTOs;
using AdSetDesafio.Infrastructure.Utilities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AdSetDesafio.Adapters.XLSX.Models;
using AdSetDesafio.Domain.Commands.Veiculo;
using AdSetDesafio.Domain.Common.Entities;
using AdSetDesafio.Domain.Services.Interfaces;
using AdSetDesafio.Infrastructure.ViewModel;

namespace AdSetDesafio.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ApiController<VeiculoController, IVeiculoService, Veiculo, VeiculoController>
    {
        private readonly IMapper _mapper;

        public VeiculoController(ILogger<VeiculoController> logger, IMapper mapper, IMediator mediator, IVeiculoService service)
            : base(logger, mediator, service)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int id)
        {
            RetornoGenericoDTO<VeiculoViewModel> retorno = new();

            try
            {
                var serviceVeiculo = (IVeiculoService)service;
                var resultado = await serviceVeiculo.GetAsync(id);
                retorno.Id = 1;
                retorno.Item = _mapper.Map<Veiculo, VeiculoViewModel>(resultado);
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "Get");
            }

            return Resultado(retorno, true);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] string filter)
        {
            RetornoGenericoDTO<IEnumerable<VeiculoViewModel>> retorno = new();

            try
            {
                var serviceVeiculo = (IVeiculoService)service;
                var result = await serviceVeiculo.GetAllAsync(filter);
                retorno.Id = 1;
                retorno.Item = _mapper.Map<IEnumerable<Veiculo>, IEnumerable<VeiculoViewModel>>(result);
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "GetAll");
            }

            return Resultado(retorno);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllPaginated([FromQuery] FiltroPaginacaoDTO filtroPaginacao)
        {
            RetornoGenericoDTO<PaginacaoDTO<VeiculoViewModel>> retorno = new();

            try
            {
                var serviceVeiculo = (IVeiculoService)service;
                var result = await serviceVeiculo.GetAllPaginated(filtroPaginacao);
                retorno.Item = _mapper.Map<PaginacaoDTO<Veiculo>, PaginacaoDTO<VeiculoViewModel>>(result);
                retorno.Id = 1;
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "GetAllPaginated");
            }

            return Resultado(retorno);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllPaginatedAndQueryable([FromQuery] FiltroPaginacaoConsultarVeiculoDTO filtroPaginacao)
        {
            RetornoGenericoDTO<PaginacaoDTO<VeiculoViewModel>> retorno = new();

            try
            {
                var serviceVeiculo = (IVeiculoService)service;
                var result = await serviceVeiculo.GetAllPaginatedAndQueryableAsync(filtroPaginacao);
                retorno.Item = _mapper.Map<PaginacaoDTO<Veiculo>, PaginacaoDTO<VeiculoViewModel>>(result);
                retorno.Id = 1;
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "GetAllPaginated");
            }

            return Resultado(retorno);
        }

        [HttpPost]
        public async Task<ActionResult> Post(VeiculoViewModel viewModel) // temp [FromBody] 
        {
            RetornoGenericoDTO<bool> retorno = new();

            try
            {
                var validations = viewModel.Validate();
                if (validations.Any())
                {
                    retorno.Id = -1;
                    retorno.Item = false;
                    retorno.Mensagem = ColetarErrosValidacao(validations);
                    return Resultado(retorno);
                }

                var command = _mapper.Map<VeiculoViewModel, VeiculoCommandCreate>(viewModel);
                var response = await mediator.Send(command);
                retorno.Id = command.Id;
                retorno.Item = response.IsValid;

                if (!retorno.Item)
                {
                    retorno.Id = -1;
                    retorno.Mensagem = ColetarErrosValidacao(response);
                }
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "Post Veiculo");
            }

            return Resultado(retorno, true);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ExportarExcelAsync([FromQuery] FiltroPaginacaoConsultarVeiculoDTO filtroPaginacao)
        {
            RetornoGenericoDTO<byte[]> retorno = new();

            try
            {
                var serviceVeiculo = (IVeiculoService)service;
                var VeiculosSelecionados = await serviceVeiculo.GetAllPaginatedAndQueryableAsync(filtroPaginacao);
                var VeiculosExport = _mapper.Map<List<Veiculo>, List<VeiculoExport>>(VeiculosSelecionados.Dados.ToList());
                var fileName = Utility.GetUniqueFileName(nameof(Veiculo)) + ".xlsx";
                var fullName = await serviceVeiculo.ExportarVeiculos(VeiculosExport, fileName);

                byte[] fileBytes = GetFile(fullName);
                System.IO.File.Delete(fullName);

                retorno.Id = 1;
                retorno.Item = fileBytes;
                retorno.Mensagem = fileName;
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "ExportarExcel");
            }

            return Resultado(retorno);
        }

        [HttpPut]
        public async Task<ActionResult> Put(VeiculoViewModel viewModel)
        {
            RetornoGenericoDTO<bool> retorno = new();

            try
            {
                var validations = viewModel.Validate();
                if (validations.Any())
                {
                    retorno.Id = -1;
                    retorno.Item = false;
                    retorno.Mensagem = ColetarErrosValidacao(validations);
                    return Resultado(retorno);
                }

                var command = _mapper.Map<VeiculoViewModel, VeiculoCommandUpdate>(viewModel);
                var response = await mediator.Send(command);
                retorno.Id = viewModel.Id;
                retorno.Item = response.IsValid;

                if (!retorno.Item)
                {
                    retorno.Id = -1;
                    retorno.Mensagem = ColetarErrosValidacao(response);
                }
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "Put");
            }

            return Resultado(retorno);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            RetornoGenericoDTO<bool> retorno = new();

            try
            {

                var command = new VeiculoCommandDelete { Id = id };
                var response = await mediator.Send(command);
                retorno.Item = response.IsValid;

                if (!retorno.Item)
                {
                    retorno.Id = -1;
                    retorno.Mensagem = ColetarErrosValidacao(response);
                }
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "Delete");
            }

            return Resultado(retorno);
        }

        private byte[] GetFile(string s)
        {
            FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);

            if (br != fs.Length)
                throw new IOException(s);

            fs.Close();

            return data;
        }

        private string WebRootPath()
        {
            var webRootPath = Directory.GetCurrentDirectory();

            if (!Directory.Exists(webRootPath))
                Directory.CreateDirectory(webRootPath);

            return webRootPath;
        }
    }
}