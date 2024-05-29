using ADSET.Application.DTOs.Enums;
using ADSET.Application.DTOs.Requests;
using ADSET.Application.Interfaces;
using ADSET.Web.DTOs.Requests;
using ADSET.Web.DTOs.Responses;
using ADSET.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ADSET.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVeiculoAppService _veiculoAppService;
        private readonly IMarcaAppService _marcaAppService;
        private readonly IOpcionalAppService _opcionalAppService;
        private readonly IFotoAppService _fotoAppService;
        private readonly IPacoteAppService _pacoteAppService;

        public HomeController(IVeiculoAppService veiculoAppService,
            IMarcaAppService marcaAppService,
            IFotoAppService fotoAppService,
            IOpcionalAppService opcionalAppService,
            IPacoteAppService pacoteAppService)
        {
            _veiculoAppService = veiculoAppService;
            _marcaAppService = marcaAppService;
            _opcionalAppService = opcionalAppService;
            _fotoAppService = fotoAppService;
            _pacoteAppService = pacoteAppService;
        }

        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> Index(string? placa, Guid? marca, Guid? modelo, int? anoMin, int? anoMax, decimal? preco, bool? foto, string? cor, int? paginaAtual, int? qtdPerPage)
        {
            var request = new FilterVeiculoRequest(placa, marca, modelo, anoMin, anoMax, preco, foto, cor, paginaAtual, qtdPerPage);

            var data = new IndexViewModel();

            var opcionais = await _opcionalAppService.GetAllAsync();
            var cores = await _veiculoAppService.GetAllColors();
            var marcas = await _marcaAppService.GetAllAsync();

            data.Opcionais = opcionais.Select(o => new DTOs.Responses.OpcionalResponse(o.Id, o.Nome, false)).ToList();
            data.Cores = cores.Select(c => new CorResponse(c, (c == cor))).ToList();
            data.Marcas = marcas.Select(m =>
                new DTOs.Responses.MarcaResponse(m.Id, m.Nome, (m.Id == marca),
                    m.Modelos.Select(mm => new DTOs.Responses.ModeloResponse(mm.Id, mm.Nome, (mm.Id == modelo)))
                    .ToList()))
                .ToList();

            data.QtdVeiculos = _veiculoAppService.GetCount();
            data.Veiculos = _veiculoAppService.GetByFilter(request.Mapping());

            return View(data);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (Guid.Empty == id) return BadRequest();

            try
            {
                if (!await _veiculoAppService.Delete(id))
                    throw new Exception("Error ao deletar o veiculo");

                return RedirectToAction("Index");

            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [ActionName("Create")]
        public async Task<IActionResult> Create()
        {
            var data = new CreateViewModel();

            var opcionais = await _opcionalAppService.GetAllAsync();
            var cores = await _veiculoAppService.GetAllColors();
            var marcas = await _marcaAppService.GetAllAsync();

            data.Opcionais = opcionais.Select(o => new DTOs.Responses.OpcionalResponse(o.Id, o.Nome, false)).ToList();
            data.Cores = cores.Select(c => new CorResponse(c, false)).ToList();
            data.Marcas = marcas.Select(m =>
            new DTOs.Responses.MarcaResponse(m.Id, m.Nome, false,
                    m.Modelos.Select(mm => new DTOs.Responses.ModeloResponse(mm.Id, mm.Nome, false))
                    .ToList()))
                .ToList();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFotos(Guid id, List<IFormFile> files)
        {
            if (id == Guid.Empty || files.Count == 0 || files.Count > 15) return BadRequest();

            var request = files.Select(f => new VeiculoFotoRequest()
            {
                Stream = f.OpenReadStream(),
                ContentType = f.ContentType,
                Nome = Guid.NewGuid().ToString(),
                VeiculoId = id,
            }).ToList();

            var response = await _fotoAppService.UpdateFotos(request);
            return RedirectToRoute(new { controller = "Home", action = "Edit", id = id });
        }

        [HttpGet("[controller]/DeleteFoto/{id}/{veiculoId}")]
        [ActionName("DeleteFoto")]
        public async Task<IActionResult> DeleteFoto(Guid id, Guid veiculoId)
        {
            if (id == Guid.Empty) return BadRequest();

            await _fotoAppService.Delete(id);

            return RedirectToRoute(new { controller = "Home", action = "Edit", id = veiculoId });

        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("MarcaId,ModeloId,Ano,Cor,Placa,Km,Preco,Opcionais")] VeiculoRequest request)
        {
            try
            {
                var result = await _veiculoAppService.Create(request);

                return RedirectToRoute(new { controller = "Home", action = "Edit", id = result.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var data = new EditViewModel();

            var opcionais = await _opcionalAppService.GetAllAsync();
            var cores = await _veiculoAppService.GetAllColors();
            var marcas = await _marcaAppService.GetAllAsync();

            data.Veiculo = await _veiculoAppService.GetById(id);

            data.Opcionais = opcionais.Select(o => new DTOs.Responses.OpcionalResponse(o.Id, o.Nome, data.Veiculo.Opcionais.Contains(o.Nome))).ToList();
            data.Cores = cores.Select(c => new CorResponse(c, (c == data.Veiculo.Cor))).ToList();
            data.Marcas = marcas.Select(m =>
                new DTOs.Responses.MarcaResponse(m.Id, m.Nome, (m.Id == data.Veiculo.MarcaId),
                    m.Modelos.Select(mm => new DTOs.Responses.ModeloResponse(mm.Id, mm.Nome, (mm.Id == data.Veiculo.ModeloId)))
                    .ToList()))
                .ToList();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,MarcaId,ModeloId,Ano,Cor,Placa,Km,Preco,Opcionais")] VeiculoEditRequest request)
        {
            try
            {
                var result = await _veiculoAppService.Update(request);

                return RedirectToRoute(new { controller = "Home", action = "Edit", id = result.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Save(Dictionary<Guid, List<TipoPacote>> request)
        {
            try
            {
                var savePacote = request.Select(r => new SavePacoteRequest(r.Key, r.Value)).ToList();

                await _pacoteAppService.SavePacotes(savePacote);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
