using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAPICarro.Data;

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
        [HttpPost("pix")]
        public async Task<ActionResult<Payment>> PostPixPayment(PixPaymentDTO paymentDTO)
        {
            Payment payment = new Payment(paymentDTO);
            payment.Pix.PixType = await _context.PixTypes.FindAsync(payment.Pix.PixType.Id);
            //pix.PixType = await _context.PixTypes.FindAsync(pix.PixType.Id);


            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // POST: api/Payments/bankSlip
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("bankSlip")]
        public async Task<ActionResult<Payment>> PostBankSlipPayment(BankSlipPaymentDTO bankSlipPaymentDTO)
        {
            /*if (_context.Payments == null)
            {
                return Problem("Entity set 'ProjAPICarroContext.Payments'  is null.");
            }*/

            /* CarOperation carOp = new(carOperationDTO);
            carOp.Car = await _context.Car.FindAsync(carOp.Car.Plate);
            carOp.Operation = await _context.Operations.FindAsync(carOp.Operation.Id);*/

            Payment payment = new Payment(bankSlipPaymentDTO);


            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
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
