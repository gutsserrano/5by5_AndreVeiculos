using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : Person
    {
        public static readonly string INSERTCLIENT = "INSERT INTO Client (Document, Income, DocumentPdf) VALUES (@Document, @Income, @DocumentPdf)";
        public static readonly string GETALL = @"SELECT People.Document, People.Name, People.BirthDate, 
                                                        Address.Id, Address.PostalCode, Address.State, Address.City, Address.PublicPlace, Address.PublicPlaceType, Address.Number, Address.Neighborhood, Address.Complement,
                                                        People.Phone, People.Email,
                                                        Client.Income, Client.DocumentPdf
                                                FROM People
                                                INNER JOIN Address ON People.AddressId = Address.Id
                                                INNER JOIN Client ON People.Document = Client.Document";

        public Decimal Income { get; set; }
        public string DocumentPdf { get; set; }
    }
}
