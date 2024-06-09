using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BuyService
    {
        private GenericRepository _genericRepository { get; set; }

        public BuyService()
        {
            _genericRepository = new GenericRepository();
        }

        public bool Insert(Buy buy)
        {
            try
            {
                Object obj = new { CarPlate = buy.Car.Plate, Price = buy.Price, BuyDate = buy.BuyDate };

                return _genericRepository.Insert(Buy.INSERT, obj);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Buy> GetAll()
        {
            List<Buy> buys = new List<Buy>();

            var result = _genericRepository.GetAll<dynamic>(Buy.GETALL);

            foreach (var item in result)
            {
                item.Car = new Car
                {
                    Plate = item.CarPlate,
                    Name = item.Name,
                    ModelYear = item.ModelYear,
                    ManufactureYear = item.ManufactureYear,
                    Color = item.Color,
                    Sold = item.Sold
                };

                // Id e IsDone vem do próprio CarOperation, pois ele que vem do FROM, os outros vem do INNER JOIN
                buys.Add(new Buy() { Id = item.Id, Car = item.Car, BuyDate = item.BuyDate});
            }

            return buys;
        }

        public Buy? Get(int id)
        {
            return GetAll().Find(b => b.Id == id);
        }
    }
}
