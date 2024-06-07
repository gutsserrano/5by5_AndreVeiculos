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
