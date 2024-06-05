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
        public DateOnly BuyDate { get; set; }
    }
}
