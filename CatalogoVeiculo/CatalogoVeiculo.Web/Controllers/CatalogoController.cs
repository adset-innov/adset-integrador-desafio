using CatalogoVeiculo.Dados.Services;
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
            var l_repository = _repositoryService.ObterTodosVeiculos();
            return View();
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
