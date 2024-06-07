using Models;
using Repositories;

namespace Services
{
    public class CarService
    {
        private GenericRepository _genericRepository { get; set; }

        public CarService()
        {
            _genericRepository = new GenericRepository();
        }

        public bool Insert(List<Car> cars)
        {
            return _genericRepository.Insert(Car.INSERT, cars);
        }

        public List<Car> GetAll()
        {
            return _genericRepository.GetAll<Car>(Car.GETALL);
        }

        public Car? Get(string plate)
        {
            return GetAll().Find(c => c.Plate == plate);
        }

        public bool Update(string plate, Car car)
        {
            //return _genericRepository.Insert(Car.UPDATE, car);
            return false;
        }

        public bool Delete(string plate)
        {
            //return _genericRepository.Delete(Car.DELETE, new { Plate = plate });
            return false;
        }
    }
}
