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
    public class BuysController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public BuysController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Buys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buy>>> GetBuys()
        {
          if (_context.Buys == null)
          {
              return NotFound();
          }
            return await _context.Buys.Include(c => c.Car).ToListAsync();
        }

        // GET: api/Buys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buy>> GetBuy(int id)
        {
          if (_context.Buys == null)
          {
              return NotFound();
          }
            var buy = await _context.Buys.Include(c => c.Car).FirstOrDefaultAsync();

            if (buy == null)
            {
                return NotFound();
            }

            return buy;
        }

        // PUT: api/Buys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuy(int id, Buy buy)
        {
            if (id != buy.Id)
            {
                return BadRequest();
            }

            _context.Entry(buy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyExists(id))
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

        // POST: api/Buys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buy>> PostBuy(BuyDTO buyDTO)
        {
            /*if (_context.Buys == null)
            {
                return Problem("Entity set 'ProjAPICarroContext.Buys'  is null.");
            }*/

            /*CarOperation carOp = new(carOperationDTO);
            carOp.Car = await _context.Car.FindAsync(carOp.Car.Plate);
            carOp.Operation = await _context.Operations.FindAsync(carOp.Operation.Id);*/

            Buy buy = new(buyDTO);
            buy.Car = await _context.Car.FindAsync(buy.Car.Plate);

            _context.Buys.Add(buy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuy", new { id = buy.Id }, buy);
        }

        // POST: api/Buys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("newCar")]
        public async Task<ActionResult<Buy>> PostBuyNewCar(Buy buy)
        {
            /*if (_context.Buys == null)
            {
                return Problem("Entity set 'ProjAPICarroContext.Buys'  is null.");
            }*/

            _context.Buys.Add(buy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuy", new { id = buy.Id }, buy);
        }

        // DELETE: api/Buys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuy(int id)
        {
            if (_context.Buys == null)
            {
                return NotFound();
            }
            var buy = await _context.Buys.FindAsync(id);
            if (buy == null)
            {
                return NotFound();
            }

            _context.Buys.Remove(buy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuyExists(int id)
        {
            return (_context.Buys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
