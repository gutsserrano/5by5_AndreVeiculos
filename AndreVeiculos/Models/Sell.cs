using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sell
    {
        public static readonly string INSERT = "INSERT INTO Sells (CarPlate, SellDate, SellPrice, ClientDocument, EmployeeDocument, PaymentId) VALUES (@CarPlate, @SellDate, @SellPrice, @ClientDocument, @EmployeeDocument, @PaymentId)";

        public int Id { get; set; }
        public Car Car { get; set; }
        public DateTime SellDate { get; set; }
        public Decimal SellPrice { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public Payment Payment { get; set; }

        public Sell()
        {
            
        }

        public Sell(SellDTO sdto)
        {
            Car car = new() { Plate = sdto.CarPlate };
            this.Car = car;

            Client client = new() { Document = sdto.ClientDocument };
            this.Client = client;

            Employee employee = new() { Document = sdto.EmployeeDocument };
            this.Employee = employee;

            Payment payment = new() { Id = sdto.PaymentId };
            this.Payment = payment;

            this.SellDate = sdto.SellDate;
            this.SellPrice = sdto.SellPrice;
        }
    }
}
