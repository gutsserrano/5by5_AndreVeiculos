using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Car
    {
        public string Plate { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public int ManufactureYear { get; set; }
        public string Color { get; set; }
        public bool Sold { get; set; }
    }
}
