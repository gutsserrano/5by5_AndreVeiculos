using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CardService
    {
        private GenericRepository _genericRepository { get; set; }

        public CardService()
        {
            _genericRepository = new GenericRepository();
        }

        public bool Insert(Card cars)
        {
            return _genericRepository.Insert(Card.INSERT, cars);
        }

        public List<Card> GetAll()
        {
            return _genericRepository.GetAll<Card>(Card.GETALL);
        }

        public Card? Get(string number)
        {
            return GetAll().Find(c => c.CardNumber == number);
        }
    }
}
