using System.Collections.Generic;

namespace ClassLibrary
{
    public interface ICarRepository
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll(int pageSize);
        void Add(Car car);
        void Update(Car car);
        void Delete(int id);
    }
}
