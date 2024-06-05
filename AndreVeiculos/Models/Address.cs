using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PublicPlace { get; set; }
        public string PublicPlaceType { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
    }
}
