using Models;
using Services;

namespace Controllers
{
    public class CarController
    {
        private CarService _carService { get; set; }

        public CarController()
        {
            _carService = new CarService();
        }

        public bool Insert(List<Car> cars)
        {
            return _carService.Insert(cars);
        }

        public List<Car> GetAll()
        {
            return _carService.GetAll();
        }

        public Car GetByPlate(string plate)
        {
            return _carService.GetByPlate(plate);
        }
    }
}
