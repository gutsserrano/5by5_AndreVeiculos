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
        public static readonly string INSERT = "INSERT INTO Pixes (PixKey, PixTypeId) VALUES (@PixKey, @PixTypeId)";
        /*public static readonly string GETALL = @"SELECT     
                                                    Payments.Id,
                                                    PixId, 
                                                    PixKey, 
                                                    PixTypeId,
                                                    PixTypes.Name
                                                FROM Payments
                                                INNER JOIN Pixes ON PixId = Pixes.Id
                                                INNER JOIN PixTypes ON Pixes.PixTypeId = PixTypes.Id";*/
        public static readonly string GETALL = @"SELECT Id, PixTypeId FROM Pixes";

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
