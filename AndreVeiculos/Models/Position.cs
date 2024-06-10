using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Position
    {
        public static readonly string INSERT = "INSERT INTO Position (Description) VALUES (@Description)";
        public static readonly string GETALL = "SELECT Id, Description FROM Position";

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
