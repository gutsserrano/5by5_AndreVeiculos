using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Buy
    {
        public static readonly string INSERT = "INSERT INTO Buys (CarPlate, Price, BuyDate) VALUES (@CarPlate, @Price, @BuyDate)";
        public static readonly string GETALL = @"SELECT Buys.Id, Buys.CarPlate, Car.Name, Car.ModelYear, 
                                                Car.ManufactureYear, Car.Color, Car.Sold, Buys.Price, Buys.BuyDate
                                                        FROM Buys
                                                        INNER JOIN Car ON Buys.CarPlate = Car.Plate";

        public int Id { get; set; }
        public Car Car { get; set; }
        public Decimal Price { get; set; }
        public DateTime BuyDate { get; set; }

        public Buy()
        {
            
        }

        public Buy(BuyDTO bdto)
        {
            Car car = new() { Plate = bdto.CarPlate};
            this.Car = car;
            this.Price = bdto.Price;
            this.BuyDate = bdto.BuyDate;
        }
    }
}
