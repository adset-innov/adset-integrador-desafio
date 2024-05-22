using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AdSetDesafio.Domain.Common.DTOs;
using AdSetDesafio.Infrastructure.Utilities;
using AdSetDesafio.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AdSetDesafio.Web.Helpers;

namespace AdSetDesafio.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ApiBaseController<VeiculoController>
    {
        public VeiculoController(
            ILogger<VeiculoController> logger,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(logger, configuration, httpContextAccessor)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
        {
            logger.LogDebug($"Carrega GetAsync");
            RetornoGenericoDTO<VeiculoViewModel> retorno = new();

            try
            {
                using var client = new HttpClientUtil<RetornoGenericoDTO<VeiculoViewModel>>(remoteServer);
                retorno = await client.Get($"API/Veiculo?id={id}");
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "GetAsync");
            }

            return Resultado(retorno.Item);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CadastrarNovoVeiculo([FromBody] VeiculoViewModel viewModel, [CallerMemberName] string callerName = "")
        {
            logger.LogDebug($"Carrega {callerName}");
            RetornoGenericoDTO<bool> retorno = new();

            try
            {
                using var client = new HttpClientUtil<RetornoGenericoDTO<bool>>(remoteServer);
                retorno = await client.Post($"API/Veiculo/", viewModel);
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, callerName);
            }

            return Resultado(retorno);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] VeiculoViewModel viewModel, [CallerMemberName] string callerName = "")
        {
            logger.LogDebug($"Carrega {callerName}");
            RetornoGenericoDTO<bool> retorno = new();

            try
            {
                using var client = new HttpClientUtil<RetornoGenericoDTO<bool>>(remoteServer);
                retorno = await client.Put($"API/Veiculo/", viewModel);
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, callerName);
            }

            return Resultado(retorno);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPaginated([FromQuery] FiltroPaginacaoDTO filtroPaginacao)
        {
            logger.LogDebug($"Carrega GetAllPaginated");
            RetornoGenericoDTO<PaginacaoDTO<VeiculoViewModel>> retorno = new();
            try
            {
                using var client = new HttpClientUtil<RetornoGenericoDTO<PaginacaoDTO<VeiculoViewModel>>>(remoteServer);
                retorno = await client.Get($"API/Veiculo/GetAllPaginated?Pagina={filtroPaginacao.Pagina}&QuantidadePorPagina={filtroPaginacao.QuantidadePorPagina}");
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "PreencherDatalist");
            }

            return Resultado(retorno.Item?.Dados ?? null);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ExportarExcelAsync([FromQuery] FiltroPaginacaoConsultarVeiculoDTO filtroPaginacao)
        {
            logger.LogDebug($"Carrega ExportarExcelAsync");
            RetornoGenericoDTO<byte[]> retorno = new();
            try
            {
                var keyValueContent = Utility.ToKeyValue(filtroPaginacao);
                var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);
                var urlEncodedString = await formUrlEncodedContent.ReadAsStringAsync();

                using var client = new HttpClientUtil<RetornoGenericoDTO<byte[]>>(remoteServer);
                retorno = await client.Post($"API/Veiculo/ExportarExcel?{urlEncodedString}", filtroPaginacao);

                if (retorno.Id == 1)
                    return File(retorno.Item, System.Net.Mime.MediaTypeNames.Application.Octet, retorno.Mensagem);
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "ExportarExcelAsync");
            }

            return Resultado(retorno.Item);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetVeiculoByFilterAsync([FromQuery] FiltroPaginacaoConsultarVeiculoDTO filtroPaginacao, [CallerMemberName] string callerName = "")
        {
            logger.LogDebug($"Carrega GetVeiculoByFilterAsync");
            RetornoGenericoDTO<PaginacaoDTO<VeiculoViewModel>> retorno = new();

            try
            {
                var keyValueContent = Utility.ToKeyValue(filtroPaginacao);
                var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);
                var urlEncodedString = await formUrlEncodedContent.ReadAsStringAsync();

                using var client = new HttpClientUtil<RetornoGenericoDTO<PaginacaoDTO<VeiculoViewModel>>>(remoteServer);
                retorno = await client.Get($"API/Veiculo/GetAllPaginatedAndQueryable?{urlEncodedString}");
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "GetVeiculoByFilterAsync");
            }

            return Resultado(retorno.Item ?? null);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> ExcluirVeiculoAsync()
        {
            logger.LogDebug($"Carrega ExcluirVeiculoAsync");
            RetornoGenericoDTO<bool> retorno = new();

            try
            {
                using var client = new HttpClientUtil<RetornoGenericoDTO<bool>>(remoteServer);
                retorno = await client.Delete($"API/Veiculo");
            }
            catch (Exception ex)
            {
                ErroProcessamento(retorno, ex, "ExcluirVeiculoAsync");
            }

            return Resultado(retorno.Item);
        }
    }
}