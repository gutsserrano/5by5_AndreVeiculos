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
using Services;

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
        [HttpGet("{type}")]
        public async Task<ActionResult<IEnumerable<Buy>>> GetBuys(string type)
        {
            if(type == "framework")
            {
                if (_context.Buys == null)
                {
                    return NotFound();
                }
                return await _context.Buys.Include(c => c.Car).ToListAsync();
            }
            else if (type == "dapper")
            {
                BuyService buyService = new();
                return buyService.GetAll();
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/Buys/5
        [HttpGet("{type}/{id}")]
        public async Task<ActionResult<Buy>> GetBuy(string type, int id)
        {
            if(type == "framework"  )
            {
                if (_context.Buys == null)
                {
                    return NotFound();
                }
                var buy = await _context.Buys.Include(c => c.Car).FirstOrDefaultAsync(c => c.Id == id);

                if (buy == null)
                {
                    return NotFound();
                }

                return buy;
            }
            else if (type == "dapper")
            {
                BuyService buyService = new();
                return buyService.Get(id);
            }
            else
            {
                return BadRequest();
            }
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
        [HttpPost("{type}")]
        public async Task<ActionResult<Buy>> PostBuy(string type, BuyDTO buyDTO)
        {
            if (type == "framework")
            {
                Buy buy = new(buyDTO);
                buy.Car = await _context.Car.FindAsync(buy.Car.Plate);

                _context.Buys.Add(buy);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBuy", new { id = buy.Id }, buy);
            }
            else if(type == "dapper")
            {
                BuyService buyService = new();
                if(buyService.Insert(new Buy(buyDTO)))
                {
                    return CreatedAtAction("GetBuy", new { type = type,  id = buyDTO.CarPlate }, buyDTO);
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

        // POST: api/Buys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("newCar")]
        public async Task<ActionResult<Buy>> PostBuyNewCar(Buy buy)
        {
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
