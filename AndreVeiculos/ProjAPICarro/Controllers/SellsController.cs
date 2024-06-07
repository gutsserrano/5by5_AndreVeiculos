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
    public class SellsController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public SellsController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Sells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sell>>> GetSells()
        {
          if (_context.Sells == null)
          {
              return NotFound();
          }
            return await _context.Sells.Include(c => c.Client).Include(e => e.Employee).Include(p => p.Payment).ToListAsync();
        }

        // GET: api/Sells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sell>> GetSell(int id)
        {
          if (_context.Sells == null)
          {
              return NotFound();
          }
            var sell = await _context.Sells.Include(c => c.Client).Include(e => e.Employee).Include(p => p.Payment).SingleOrDefaultAsync(s => s.Id == id);

            if (sell == null)
            {
                return NotFound();
            }

            return sell;
        }

        // PUT: api/Sells/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSell(int id, Sell sell)
        {
            if (id != sell.Id)
            {
                return BadRequest();
            }

            _context.Entry(sell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellExists(id))
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

        // POST: api/Sells
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sell>> PostSell(SellDTO sellDTO)
        {
            if (_context.Sells == null)
            {
                return Problem("Entity set 'ProjAPICarroContext.Sells'  is null.");
            }

            Sell sell = new Sell(sellDTO);
            sell.Car = await _context.Car.FindAsync(sell.Car.Plate);
            sell.Client = await _context.Clients.FindAsync(sell.Client.Document);
            sell.Employee = await _context.Employees.FindAsync(sell.Employee.Document);
            sell.Payment = await _context.Payments.FindAsync(sell.Payment.Id);

            sell.Car.Sold = true;

            _context.Sells.Add(sell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSell", new { id = sell.Id }, sell);
        }

        // DELETE: api/Sells/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSell(int id)
        {
            if (_context.Sells == null)
            {
                return NotFound();
            }
            var sell = await _context.Sells.FindAsync(id);
            if (sell == null)
            {
                return NotFound();
            }

            _context.Sells.Remove(sell);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SellExists(int id)
        {
            return (_context.Sells?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
