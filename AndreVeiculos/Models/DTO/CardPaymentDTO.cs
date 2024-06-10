using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class CardPaymentDTO
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string NameInCard { get; set; }
        public string SecurityNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
