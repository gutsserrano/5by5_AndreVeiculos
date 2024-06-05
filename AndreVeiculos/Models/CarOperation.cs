using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarOperation
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public Operation Operation { get; set; }
    }
}
