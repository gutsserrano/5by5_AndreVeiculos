using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarOperation
    {
        public static readonly string INSERT = "INSERT INTO CarOperation (CarPlate, OperationId, IsDone) VALUES (@CarPlate, @OperationId, @IsDone)";
        public static readonly string GETALL = @"SELECT CarOperation.Id, CarOperation.CarPlate, Car.Name, Car.ModelYear, 
                                                Car.ManufactureYear, Car.Color, Car.Sold, CarOperation.OperationId, CarOperation.IsDone, Operation.Description
                                                        FROM CarOperation
                                                        INNER JOIN Car ON CarOperation.CarPlate = Car.Plate
                                                        INNER JOIN Operation ON CarOperation.OperationId = Operation.Id";

        public int Id { get; set; }
        public Car Car { get; set; }
        public Operation Operation { get; set; }
        public bool IsDone { get; set; }
    }
}
