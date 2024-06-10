using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentService
    {
        private GenericRepository _genericRepository { get; set; }

        public PaymentService()
        {
            _genericRepository = new GenericRepository();
        }

        public bool Insert(Payment payment)
        {
            if(payment.Card != null)
            {
                Object card = new { CardNumber = payment.Card.CardNumber, SecurityNumber = payment.Card.SecurityNumber, ExpirationDate = payment.Card.ExpirationDate, NameInCard = payment.Card.NameInCard };

                if(!_genericRepository.Insert(Card.INSERT, card))
                {
                    return false;
                }

                return _genericRepository.Insert(Payment.INSERTCARD, new { CardNumber = payment.Card.CardNumber, PaymentDate = payment.PaymentDate });
            }
            else if (payment.BankSlip != null)
            {
                Object bankSlip = new { Number = payment.BankSlip.Number, ExpirationDate = payment.BankSlip.ExpirationDate };

                if (!_genericRepository.Insert(BankSlip.INSERT, bankSlip))
                {
                    return false;
                }

                return _genericRepository.Insert(Payment.INSERTBANKSLIP, new { BankSlipId = _genericRepository.GetAll<BankSlip>(BankSlip.GETALL).Last().Id, PaymentDate = payment.PaymentDate });
            }
            /*else if (payment.Pix != null)
            {
                return _genericRepository.Insert(Payment.INSERTPIX, new { PaymentId = payment.Id, PixTypeId = payment.Pix.PixTypeId, PixKey = payment.Pix.PixKey });
            }*/
            else
            {
                return false;
            }
        }

        /*public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            var clientResult = _genericRepository.GetAll<dynamic>(Client.GETALL);

            foreach (var item in clientResult)
            {

                item.Address = new Address
                {
                    Id = item.Id,
                    PostalCode = item.PostalCode,
                    State = item.State,
                    City = item.City,
                    PublicPlace = item.PublicPlace,
                    PublicPlaceType = item.PublicPlaceType,
                    Number = item.Number,
                    Neighborhood = item.Neighborhood,
                    Complement = item.Complement
                };

                Client client = new()
                {
                    Document = item.Document,
                    Name = item.Name,
                    BirthDate = item.BirthDate,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email,
                    Income = item.Income,
                    DocumentPdf = item.DocumentPdf
                };
                // Id e IsDone vem do próprio CarOperation, pois ele que vem do FROM, os outros vem do INNER JOIN
                clients.Add(client);
            }

            return clients;
        }

        public Payment? Get(string id)
        {
            return GetAll().Find(p => p.Id == id);
        }*/
    }
}
