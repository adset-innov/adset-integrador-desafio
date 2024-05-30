using AdSetDesafio.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace AdSetDesafio.Web.Controllers
{
    public class VeiculoController : BaseController
    {
        public VeiculoController(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(configuration, httpContextAccessor)
        {

        }

        [Route("[controller]/ConsultarVeiculos/")]
        public IActionResult ConsultarVeiculos()
        {

            return View("~/Views/Home/Index.cshtml");
        }
    }
}