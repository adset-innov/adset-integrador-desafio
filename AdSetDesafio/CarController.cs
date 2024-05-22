using Microsoft.AspNetCore.Mvc;
using AdSetDesafio.Services;
using ClassLibrary;

namespace AdSetDesafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CarController(CarService carService, IHttpContextAccessor httpContextAccessor)
        {
            _carService = carService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carService.GetCars();
            return Ok(cars);
        }

        [HttpPost]
        public IActionResult AddCar([FromForm] Car car, List<IFormFile> fotos)
        {
            if (car == null)
            {
                return BadRequest();
            }

            foreach (var foto in fotos)
            {
                using (var stream = foto.OpenReadStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        byte[] bytes = memoryStream.ToArray();

                        car.Fotos.Add(bytes);
                    }
                }
            }

            _carService.AddCar(car);
            return Ok();
        }

        [HttpGet]
        [Route("GetImage/{id}")]
        public IActionResult GetImage(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null || car.Fotos.Count == 0)
            {
                return NotFound();
            }

            byte[] imageBytes = car.Fotos[0];
            return File(imageBytes, "image/jpeg");
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult SearchCars(string placa = null, string modelo = null, int? anoMin = null, int? anoMax = null, string preco = null, string fotos = null, string opcionais = null, string cor = null)
        {
            var filteredCars = _carService.SearchCars(placa, modelo, anoMin ?? 0, anoMax ?? 0, preco, fotos, opcionais, cor);
            return Ok(filteredCars);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            _carService.DeleteCar(car);
            return NoContent(); 
        }

        [HttpPatch("{id}")] 
        public IActionResult UpdateCar([FromRoute] int id, [FromForm] Car car, List<IFormFile> fotos) 
        {
            var existingCar = _carService.GetCarById(id);
            if (existingCar == null)
            {
                return NotFound();
            }

            existingCar.Placa = car.Placa;
            existingCar.Modelo = car.Modelo;
            existingCar.Ano = car.Ano;
            existingCar.Preco = car.Preco;
            existingCar.Cor = car.Cor;

            existingCar.Opcionais.Clear();
            existingCar.Opcionais.AddRange(car.Opcionais);

            if (fotos.Count > 0)
            {
                existingCar.Fotos.Clear();
                foreach (var foto in fotos)
                {
                    using (var stream = foto.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            byte[] bytes = memoryStream.ToArray();

                            existingCar.Fotos.Add(bytes);
                        }
                    }
                }
            }

            _carService.UpdateCar(existingCar);
            return NoContent();
        }
    }
}
