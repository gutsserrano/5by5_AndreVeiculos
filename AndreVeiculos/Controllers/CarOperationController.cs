using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class CarOperationController
    {
        private CarOperationService _carOperationService { get; set; }

        public CarOperationController()
        {
            _carOperationService = new CarOperationService();
        }

        public bool Insert(Car car, Operation operation)
        {
            return _carOperationService.Insert(car, operation);
        }

        public List<CarOperation> GetAll()
        {
            return _carOperationService.GetAll();
        }
    }
}
