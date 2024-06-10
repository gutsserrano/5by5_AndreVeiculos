using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BankSlip
    {
        public static readonly string INSERT = "INSERT INTO BankSlips (Number, ExpirationDate) VALUES (@Number, @ExpirationDate)";
        public static readonly string GETALL = "SELECT Id, Number, ExpirationDate FROM BankSlips";

        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
