using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAPICarro.Data;
using Services;

namespace ProjAPICarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public PaymentsController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
          if (_context.Payments == null)
          {
              return NotFound();
          }
            
            if(_context.Payments.Include(p => p.Pix) != null)
            {
                return await _context.Payments.Include(p => p.Pix).Include(p => p.Pix.PixType).Include(b => b.BankSlip).Include(c => c.Card).ToListAsync();
            }
            else if(_context.Payments.Include(b => b.BankSlip) != null)
            {
                return await _context.Payments.Include(b => b.BankSlip).ToListAsync();
            }
            else
            {
                return await _context.Payments.Include(c => c.Card).ToListAsync();
            }

        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
          if (_context.Payments == null)
          {
              return NotFound();
          }
            var payment = await _context.Payments.Include(p => p.Pix).Include(p => p.Pix.PixType).Include(b => b.BankSlip).Include(c => c.Card).SingleOrDefaultAsync(p => p.Id == id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Payments/pix
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("pix/{type}")]
        public async Task<ActionResult<Payment>> PostPixPayment(string type, PixPaymentDTO pixPaymentDTO)
        {
            if(type == "framework")
            {
                Pix pix = new Pix()
                {
                    PixKey = pixPaymentDTO.PixKey,
                    PixType = new PixType() { Id = pixPaymentDTO.PixTypeId }
                };

                pix.PixType = await _context.PixTypes.FindAsync(pix.PixType.Id);
                _context.Pixes.Add(pix);
                await _context.SaveChangesAsync();


                Payment payment = new Payment(pixPaymentDTO);
                payment.Pix = pix;
                payment.Pix.PixType = pix.PixType;

                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
            }
            else if (type == "dapper")
            {
                PaymentService paymentService = new PaymentService();
                Payment payment = new(pixPaymentDTO);
                if (paymentService.Insert(payment))
                {
                    return CreatedAtAction("GetPayment", new { /*type = type,*/ id = payment.Id }, payment);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Payments/bankSlip
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("bankSlip/{type}")]
        public async Task<ActionResult<Payment>> PostBankSlipPayment(string type, BankSlipPaymentDTO bankSlipPaymentDTO)
        {
            if(type == "framework")
            {
                Payment payment = new Payment(bankSlipPaymentDTO);

                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
            }
            else if (type == "dapper")
            {
                PaymentService paymentService = new PaymentService();
                Payment payment = new(bankSlipPaymentDTO);
                if (paymentService.Insert(payment))
                {
                    return CreatedAtAction("GetPayment", new { /*type = type,*/ id = payment.Id }, payment);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Payments/bankSlip
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("card/{type}")]
        public async Task<ActionResult<Payment>> PostCardPayment(string type, CardPaymentDTO cardPaymentDTO)
        {
            if(type == "framework")
            {
                Payment payment = new Payment(cardPaymentDTO);

                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
            }
            else if (type == "dapper")
            {
                PaymentService paymentService = new PaymentService();
                Payment payment = new(cardPaymentDTO);
                if(paymentService.Insert(payment))
                {
                    return CreatedAtAction("GetPayment", new { /*type = type,*/ id = payment.Id }, payment);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return (_context.Payments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
