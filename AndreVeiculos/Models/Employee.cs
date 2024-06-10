using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : Person
    {
        public static readonly string INSERTEMPLOYEE = "INSERT INTO Employee (Document, PositionId, ComissionValue, Commission) VALUES (@Document, @PositionId, @ComissionValue, @Commission)";
        public static readonly string GETALL = @"SELECT People.Document, People.Name, People.BirthDate, 
                                                        Address.Id, Address.PostalCode, Address.State, Address.City, Address.PublicPlace, Address.PublicPlaceType, Address.Number, Address.Neighborhood, Address.Complement,
                                                        People.Phone, People.Email,
                                                        Employee.PositionId, Position.Description,
                                                        Employee.ComissionValue, Employee.Commission
                                                FROM People
                                                INNER JOIN Address ON People.AddressId = Address.Id
                                                INNER JOIN Position ON Employee.PositionId = Position.Id
                                                INNER JOIN Employee ON People.Document = Employee.Document";

        public Position Position { get; set; }
        public Decimal ComissionValue { get; set; }
        public Decimal Commission { get; set; }
    }
}
