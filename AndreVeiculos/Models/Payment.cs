using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Card Card { get; set; }
        public BankSlip BankSlip { get; set; }
        public Pix Pix { get; set; }
        public DateOnly PaymentDate { get; set; }
    }
}
