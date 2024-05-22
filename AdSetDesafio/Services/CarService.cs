using ClassLibrary;
using System.Collections.Generic;
using System.Linq;

namespace AdSetDesafio.Services
{
    public class CarService
    {
        private readonly WebAppDbContext _dbContext;

        public CarService(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Car> GetCars()
        {
            return _dbContext.Cars.ToList();
        }

        public void AddCar(Car car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            _dbContext.Cars.Remove(car);
            _dbContext.SaveChanges();
        }

        public Car GetCarById(int id)
        {
            return _dbContext.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> SearchCars(string placa, string modelo, int anoMin, int anoMax, string preco, string fotos, string opcionais, string cor)
        {
            var query = _dbContext.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(placa))
            {
                query = query.Where(c => c.Placa.Contains(placa));
            }

            if (!string.IsNullOrEmpty(modelo))
            {
                query = query.Where(c => c.Modelo.Contains(modelo));
            }


            return query.ToList();
        }

        public void UpdateCar(Car car)
        {
            _dbContext.Cars.Update(car);
            _dbContext.SaveChanges();
        }
    }
}
