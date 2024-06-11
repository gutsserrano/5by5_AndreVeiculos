using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SellService
    {
        private GenericRepository _genericRepository { get; set; }

        public SellService()
        {
            _genericRepository = new GenericRepository();
        }

        public bool Insert(Sell sell, Car car, Client client, Employee employee, Payment payment)
        {
            try
            {
                Object obj = new {CarPlate = car.Plate, SellDate = sell.SellDate, SellPrice = sell.SellPrice, ClientDocument = client.Document, EmployeeDocument = employee.Document, PaymentId = payment.Id};

                return _genericRepository.Insert(Sell.INSERT, obj);
            }
            catch (Exception)
            {
                return false;
            }
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

        public CarOperation? Get(int id)
        {
            return GetAll().Find(co => co.Id == id);
        }
    }
}
