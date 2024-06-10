using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Payment
    {
        public static readonly string INSERTCARD = "INSERT INTO Payments (CardNumber, PaymentDate) VALUES (@CardNumber, @PaymentDate)";
        public static readonly string INSERTBANKSLIP = "INSERT INTO Payments (BankSlipId, PaymentDate) VALUES (@BankSlipId, @PaymentDate)";
        public static readonly string INSERTPIX = "INSERT INTO Payments (PaymentId, PixTypeId, PixKey) VALUES (@PaymentId, @PixTypeId, @PixKey)";


        public int Id { get; set; }
        public Card? Card { get; set; }
        public BankSlip? BankSlip { get; set; }
        public Pix? Pix { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment()
        {
            
        }

        public Payment(PixPaymentDTO ppdto)
        {
            Pix pix = new() { PixKey = ppdto.PixKey, PixType = new() { Id = ppdto.PixTypeId } };
            this.Pix = pix;
            this.Id = ppdto.Id;
            this.PaymentDate = ppdto.PaymentDate;
        }

        public Payment(BankSlipPaymentDTO bpdto)
        {
            BankSlip bankSlip = new() { Number = bpdto.BankSlipNumber, ExpirationDate = bpdto.ExpirationDate };
            this.BankSlip = bankSlip;
            this.Id = bpdto.Id;
            this.PaymentDate = bpdto.PaymentDate;
        }

        public Payment(CardPaymentDTO cpdto)
        {
            Card card = new() { CardNumber = cpdto.CardNumber, SecurityNumber = cpdto.SecurityNumber, ExpirationDate = cpdto.ExpirationDate, NameInCard = cpdto.NameInCard };
            this.Card = card;
            this.Id = cpdto.Id;
            this.PaymentDate = cpdto.PaymentDate;
        }
    }
}
