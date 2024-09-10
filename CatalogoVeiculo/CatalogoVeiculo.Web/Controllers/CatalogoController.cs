using CatalogoVeiculo.Dados.Services;
using CatalogoVeiculo.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoVeiculo.Web.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly IRepositoryService _repositoryService;
        public CatalogoController(ILogger<CatalogoController> logger, IRepositoryService a_repositoryService)
        {
            _logger = logger;
            _repositoryService = a_repositoryService;
        }
        // GET: CatalogoController
        public ActionResult Index()
        
        {
            var l_Veiculos = _repositoryService.ObterTodosVeiculos();
            var l_Opcionais = _repositoryService.ObterTodosOpcionais();

            var l_Model = new List<CatalogoViewModel>();

            if (l_Veiculos.Count() > 0)
            {
                foreach (var item in l_Veiculos)
                {
                    l_Model.Add(new CatalogoViewModel { 
                        Marca = item.Marca,
                        Modelo = item.Modelo,
                        Ano = item.Ano,
                        Placa = item.Placa,
                        Cor = item.Cor,
                        Preco = item.Preco,
                        Km = item.Km,
                        Opcionais = item.Opcionais,
                        Fotos = item.Fotos
                    });
                }
                
                ViewBag.Opcionais = l_Opcionais ?? null;

                return View(l_Model);
            }
            else
            {
                return View(l_Model);
            }
        }

        // GET: CatalogoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatalogoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatalogoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatalogoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
