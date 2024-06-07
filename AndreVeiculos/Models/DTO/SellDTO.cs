using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SellDTO
    {
        public int Id { get; set; }
        public string CarPlate { get; set; }
        public DateTime SellDate { get; set; }
        public Decimal SellPrice { get; set; }
        public string ClientDocument { get; set; }
        public string EmployeeDocument { get; set; }
        public int PaymentId { get; set; }
    }
}
