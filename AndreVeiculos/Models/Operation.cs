using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Operation
    {
        public static readonly string INSERT = "INSERT INTO Operation (Description) VALUES (@Description)";
        public static readonly string GETALL = "SELECT Id, Description FROM Operation";

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
