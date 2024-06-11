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
                return InsertCard(payment);
            }
            else if (payment.BankSlip != null)
            {
                return InsertBankSlip(payment);
            }
            else if (payment.Pix != null)
            {
                return InsertPix(payment);
            }
            else
            {
                return false;
            }
        }

        private bool InsertCard(Payment payment)
        {
            Object card = new { CardNumber = payment.Card.CardNumber, SecurityNumber = payment.Card.SecurityNumber, ExpirationDate = payment.Card.ExpirationDate, NameInCard = payment.Card.NameInCard };

            if (!_genericRepository.Insert(Card.INSERT, card))
            {
                return false;
            }

            return _genericRepository.Insert(Payment.INSERTCARD, new { CardNumber = payment.Card.CardNumber, PaymentDate = payment.PaymentDate });
        }

        private bool InsertBankSlip(Payment payment)
        {
            Object bankSlip = new { Number = payment.BankSlip.Number, ExpirationDate = payment.BankSlip.ExpirationDate };

            if (!_genericRepository.Insert(BankSlip.INSERT, bankSlip))
            {
                return false;
            }

            return _genericRepository.Insert(Payment.INSERTBANKSLIP, new { BankSlipId = _genericRepository.GetAll<BankSlip>(BankSlip.GETALL).Last().Id, PaymentDate = payment.PaymentDate });
        }

        private bool InsertPix(Payment payment)
        {
            Object pix = new { PixKey = payment.Pix.PixKey, PixTypeId = payment.Pix.PixType.Id };

            if (!_genericRepository.Insert(Pix.INSERT, pix))
            {
                return false;
            }

            return _genericRepository.Insert(Payment.INSERTPIX, new { PixId = _genericRepository.GetAll<Pix>(Pix.GETALL).Last().Id, PaymentDate = payment.PaymentDate });
        }

    }
}
