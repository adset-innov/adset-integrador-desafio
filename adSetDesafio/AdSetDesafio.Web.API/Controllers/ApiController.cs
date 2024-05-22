using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdSetDesafio.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdSetDesafio.Web.API.Controllers
{
    [ApiController]
    public abstract class ApiController<TController, TServiceReader, TEntity, TLogger> : ControllerBase
        where TServiceReader : IServiceReader<TEntity>
    {
        private readonly ICollection<string> erros = new List<string>();
        protected readonly ILogger<TLogger> logger;
        protected readonly IMediator mediator;
        protected readonly IServiceReader<TEntity> service;
        protected readonly string user;

        public ApiController(ILogger<TLogger> logger, IMediator mediator, IServiceReader<TEntity> service) : base()
        {
            this.logger = logger;
            this.mediator = mediator;
            this.service = service;
        }

        protected ActionResult Resultado(object result = null, bool aceitarErros = true)
        {
            if (NaoExisteErro() || aceitarErros)
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", erros.ToArray() }
            }));
        }

        protected string ColetarErrosValidacao(ValidationResult validationResult)
        {
            var erros = new StringBuilder();
            var contadorErros = 0;

            foreach (var error in validationResult.Errors)
                erros.AppendFormat("{0} - {1}; ", ++contadorErros, error.ErrorMessage);

            return erros.ToString();
        }

        protected string ColetarErrosValidacao(IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> validationResult)
        {
            var erros = new StringBuilder();
            var contadorErros = 0;

            foreach (var erro in validationResult)
                erros.AppendFormat("{0} - {1}; ", ++contadorErros, erro.ErrorMessage);

            return erros.ToString();
        }

        protected void ErroProcessamento(dynamic retornoDTO, Exception exception, string descricao = "")
        {
            AddicionarErroRetorno(exception.Message);
            AddicionarErroLog(retornoDTO, exception, descricao);
        }

        private bool NaoExisteErro()
            => !erros.Any();

        private void AddicionarErroRetorno(string erro)
            => erros.Add(erro);

        private void AddicionarErroLog(dynamic retornoDTO, Exception exception, string descricao)
        {
            retornoDTO.Id = -1;
            retornoDTO.Mensagem = exception.Message;
            logger.LogError(exception, descricao);
        }
    }
}