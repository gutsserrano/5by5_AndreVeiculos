using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PixType
    {
        public static readonly string INSERT = "INSERT INTO PixTypes (Name) VALUES (@Name)";
        public static readonly string GETALL = "SELECT Id, Name FROM PixTypes";

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
