using ClassLibrary;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdSetDesafio.Services;
using System.Linq;

namespace AdSetDesafio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CarService _carService;

        public IndexModel(CarService carService)
        {
            _carService = carService;
        }

        public List<Car> Cars { get; set; }

        public int TotalCarsCount { get; set; }
        public int CarsWithPhotosCount { get; set; }
        public int CarsWithoutPhotosCount { get; set; }

        public void OnGet()
        {
            Cars = _carService.GetCars();

            TotalCarsCount = Cars.Count;

            CarsWithPhotosCount = Cars.Count(car => car.Fotos.Any());

            CarsWithoutPhotosCount = TotalCarsCount - CarsWithPhotosCount;
        }
    }
}
