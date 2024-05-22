using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using AdSetDesafio.Infrastructure.ViewModel;
using System;
using System.Diagnostics;

namespace AdSetDesafio.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(configuration, httpContextAccessor)
        {

        }

        public IActionResult Index()
        {

            return RedirectToAction("ConsultarVeiculos", "Veiculo");
        }
    }
}