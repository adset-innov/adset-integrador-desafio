using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdSetDesafio.Web.Controllers.API
{
    public abstract class ApiBaseController<TController> : BaseController
    {
        protected readonly ILogger<TController> logger;
        private readonly ICollection<string> _errors;

        public ApiBaseController(
            ILogger<TController> logger,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(configuration, httpContextAccessor)
        {
            this.logger = logger;
            _errors = new List<string>();
        }

        protected ActionResult Resultado(object result = null)
        {
            if (NaoExisteErro())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", _errors.ToArray() }
            }));
        }

        protected void ErroProcessamento(dynamic retornoDTO, Exception exception, string descricao = "")
        {
            AddicionarErroRetorno(exception.Message);
            AddicionarErroLog(retornoDTO, exception, descricao);
        }

        private bool NaoExisteErro()
            => !_errors.Any();

        private void AddicionarErroRetorno(string erro)
            => _errors.Add(erro);

        private void AddicionarErroLog(dynamic retornoDTO, Exception exception, string descricao)
        {
            retornoDTO.Id = -1;
            retornoDTO.Mensagem = exception.Message;
            logger.LogError(exception, descricao);
        }
    }
}