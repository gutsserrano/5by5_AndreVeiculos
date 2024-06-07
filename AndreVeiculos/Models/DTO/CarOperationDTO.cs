using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class CarOperationDTO
    {
        public string CarPlate { get; set; }
        public int operationId { get; set; }
        public bool IsDone { get; set; }
    }
}
