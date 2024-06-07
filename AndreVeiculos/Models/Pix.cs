using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pix
    {
        public int Id { get; set; }
        public PixType PixType { get; set; }
        public string PixKey { get; set; }

        public Pix()
        {
            
        }

        public Pix(PixDTO pdto)
        {
            PixType pt = new PixType
            {
                Id = pdto.PixTypeId
            };
            Id = pdto.Id;
            PixType = pt;
            PixKey = pdto.PixKey;
        }
    }
}
