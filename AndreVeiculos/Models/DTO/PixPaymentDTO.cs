using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class PixPaymentDTO
    {
        public int Id { get; set; }
        public string PixKey { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PixTypeId { get; set; }
    }
}
