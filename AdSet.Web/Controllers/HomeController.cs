using AdSet.Dominio.Services;
using Microsoft.AspNetCore.Mvc;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositoryService _repositoryService;

    public HomeController(ILogger<HomeController> logger, IRepositoryService a_repositoryService)
    {
        _logger = logger;
        _repositoryService = a_repositoryService;
    }

    public IActionResult Index()
    {
        _repositoryService.GetAll();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
