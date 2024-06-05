using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BankSlip
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
