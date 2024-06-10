using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Person
    {
        public static readonly string INSERT = "INSERT INTO People (Document, Name, BirthDate, AddressId, Phone, Email) VALUES (@Document, @Name, @BirthDate, @AddressId, @Phone, @Email)";

        public string Document { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
