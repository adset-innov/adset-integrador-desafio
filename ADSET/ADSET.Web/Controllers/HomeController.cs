using ADSET.Application.Interfaces;
using ADSET.Domain.Interfaces.Services;
using ADSET.Web.DTOs.Responses;
using ADSET.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ADSET.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVeiculoAppService _veiculoAppService;
        private readonly IMarcaAppService _marcaAppService;
        private readonly IOpcionalAppService _opcionalAppService;
        private readonly IFotoAppService _fotoAppService;


        public HomeController(ILogger<HomeController> logger, 
            IVeiculoAppService veiculoAppService, 
            IMarcaAppService marcaAppService, 
            IOpcionalAppService opcionalAppService, 
            IFotoAppService fotoAppService)
        {
            _logger = logger;
            _veiculoAppService = veiculoAppService;
            _marcaAppService = marcaAppService;
            _opcionalAppService = opcionalAppService;
            _fotoAppService = fotoAppService;
        }

        public async Task<IActionResult> Index()
        {
            var data = new IndexViewModel();

            var opcionais = await _opcionalAppService.GetAllAsync();
            var cores = await _veiculoAppService.GetAllColors();
            var marcas = await _marcaAppService.GetAllAsync();
            data.Opcionais = opcionais.Select(o => new OpcionalResponse(o.Id, o.Nome, false)).ToList();
            data.Cores = cores.Select(c => new CorResponse(c, false)).ToList();
            data.Marcas = marcas.Select(m => 
                new MarcaResponse(m.Id, m.Nome, false, 
                    m.Modelos.Select(mm => new ModeloResponse(mm.Id, mm.Nome, false))
                    .ToList()))
                .ToList();

            data.Veiculos = _veiculoAppService.GetByFilter(new Application.DTOs.Request.FilterPaginationRequest(1, 10));
            
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
