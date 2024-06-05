using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sell
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public DateOnly SellDate { get; set; }
        public Decimal SellPrice { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public Payment Payment { get; set; }
    }
}
