using AdSetDesafio.Infrastructure.ViewModel;
using AdSetDesafio.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AdSetDesafio.Web.Controllers
{
    public class CadastrarVeiculoController : BaseController
    {
        public CadastrarVeiculoController(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(configuration, httpContextAccessor)
        {

        }

        [Route("[controller]/Cadastrar/")]
        public IActionResult Cadastrar()
        {
            var opcionais = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "" },
                new SelectListItem { Value = "1", Text = "AirBag" },
                new SelectListItem { Value = "2", Text = "Alarme" },
                new SelectListItem { Value = "3", Text = "Freios ABS" }
            };

            ViewData["Opcional"] = new SelectList(opcionais, "Value", "Text");

            var pacoteICarros = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "" },
                new SelectListItem { Value = "1", Text = "Diamante Feirão" },
                new SelectListItem { Value = "2", Text = "Diamante" },
                new SelectListItem { Value = "3", Text = "Platinum" }
            };

            ViewData["ICarros"] = new SelectList(pacoteICarros, "Value", "Text");

            var pacoteWebMotors = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "" },
                new SelectListItem { Value = "1", Text = "Básico" }
            };

            ViewData["WebMotors"] = new SelectList(pacoteWebMotors, "Value", "Text");

            return View("~/Views/Cadastrar/Index.cshtml", new VeiculoCadastroViewModel { });
        }
    }
}