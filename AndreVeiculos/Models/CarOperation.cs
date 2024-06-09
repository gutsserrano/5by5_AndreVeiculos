using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO;

namespace Models
{
    public class CarOperation
    {
        public static readonly string INSERT = "INSERT INTO CarOperations (CarPlate, OperationId, IsDone) VALUES (@CarPlate, @OperationId, @IsDone)";
        public static readonly string GETALL = @"SELECT CarOperations.Id, CarOperations.CarPlate, Car.Name, Car.ModelYear, 
                                                Car.ManufactureYear, Car.Color, Car.Sold, CarOperations.OperationId, CarOperations.IsDone, Operations.Id, Operations.Description
                                                        FROM CarOperations
                                                        INNER JOIN Car ON CarOperations.CarPlate = Car.Plate
                                                        INNER JOIN Operations ON CarOperations.OperationId = Operations.Id";

        public int Id { get; set; }
        public Car Car { get; set; }
        public Operation Operation { get; set; }
        public bool IsDone { get; set; }

        public CarOperation()
        {
            
        }

        public CarOperation(CarOperationDTO cod)
        {
            Car car = new Car { Plate = cod.CarPlate };
            Operation op = new Operation { Id = cod.operationId };
            this.Car = car;
            this.Operation = op;
            this.IsDone = cod.IsDone;
        }
    }
}
