using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CarOperationService
    {
        private GenericRepository _genericRepository { get; set; }

        public CarOperationService()
        {
            _genericRepository = new GenericRepository();
        }

        public bool Insert(Car car, Operation operation)
        {
            Object obj = new { CarPlate = car.Plate, OperationId = operation.Id, IsDone = false };

            return _genericRepository.Insert(CarOperation.INSERT, obj);
        }

        public List<CarOperation> GetAll()
        {
            List<CarOperation> carOperations = new List<CarOperation>();

            var result = _genericRepository.GetAll<dynamic>(CarOperation.GETALL);

            foreach (var item in result)
            {
                item.Car = new Car
                {
                    Plate = item.CarPlate,
                    Name = item.Name,
                    ModelYear = item.ModelYear,
                    ManufactureYear = item.ManufactureYear,
                    Color = item.Color,
                    Sold = item.Sold
                };

                item.Operation = new Operation
                {
                    Id = item.OperationId,
                    Description = item.Description
                };
                                                    // Id e IsDone vem do próprio CarOperation, pois ele que vem do FROM, os outros vem do INNER JOIN
                carOperations.Add(new CarOperation() { Id = item.Id, Car = item.Car, Operation = item.Operation, IsDone = item.IsDone });
            }

            return carOperations;
        }
    }
}
