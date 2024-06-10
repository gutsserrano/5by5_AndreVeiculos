using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Card
    {
        public static readonly string INSERT  = "INSERT INTO Card (CardNumber, SecurityNumber, ExpirationDate, NameInCard) VALUES (@CardNumber, @SecurityNumber, @ExpirationDate, @NameInCard)";
        public static readonly string GETALL = "SELECT CardNumber, SecurityNumber, ExpirationDate, NameInCard FROM Card";

        [Key]
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string NameInCard { get; set; }
    }
}
