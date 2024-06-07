using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Car
    {
        public static readonly string GETALL = "SELECT Plate, Name, ModelYear, ManufactureYear, Color, Sold FROM Car";
        public static readonly string INSERT = "INSERT INTO Car (Plate, Name, ModelYear, ManufactureYear, Color, Sold) VALUES (@Plate, @Name, @ModelYear, @ManufactureYear, @Color ,@Sold)";

        [Key]
        public string Plate { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public int ManufactureYear { get; set; }
        public string Color { get; set; }
        public bool Sold { get; set; }

        
    }
}
