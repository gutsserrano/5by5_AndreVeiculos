using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Operation
    {
        public static readonly string INSERT = "INSERT INTO Operations (Description) VALUES (@Description)";
        public static readonly string GETALL = "SELECT Id, Description FROM Operations";

        public int Id { get; set; }
        public string Description { get; set; }
    }
}
