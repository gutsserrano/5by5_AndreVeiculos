using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Card
    {
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string NameInCard { get; set; }
    }
}
