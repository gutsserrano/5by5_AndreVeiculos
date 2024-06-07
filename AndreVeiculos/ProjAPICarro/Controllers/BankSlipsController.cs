using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAPICarro.Data;

namespace ProjAPICarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankSlipsController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public BankSlipsController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/BankSlips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankSlip>>> GetBankSlips()
        {
          if (_context.BankSlips == null)
          {
              return NotFound();
          }
            return await _context.BankSlips.ToListAsync();
        }

        // GET: api/BankSlips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankSlip>> GetBankSlip(int id)
        {
          if (_context.BankSlips == null)
          {
              return NotFound();
          }
            var bankSlip = await _context.BankSlips.FindAsync(id);

            if (bankSlip == null)
            {
                return NotFound();
            }

            return bankSlip;
        }

        // PUT: api/BankSlips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankSlip(int id, BankSlip bankSlip)
        {
            if (id != bankSlip.Id)
            {
                return BadRequest();
            }

            _context.Entry(bankSlip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankSlipExists(id))
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

        // POST: api/BankSlips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankSlip>> PostBankSlip(BankSlip bankSlip)
        {
          if (_context.BankSlips == null)
          {
              return Problem("Entity set 'ProjAPICarroContext.BankSlips'  is null.");
          }
            _context.BankSlips.Add(bankSlip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankSlip", new { id = bankSlip.Id }, bankSlip);
        }

        // DELETE: api/BankSlips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankSlip(int id)
        {
            if (_context.BankSlips == null)
            {
                return NotFound();
            }
            var bankSlip = await _context.BankSlips.FindAsync(id);
            if (bankSlip == null)
            {
                return NotFound();
            }

            _context.BankSlips.Remove(bankSlip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BankSlipExists(int id)
        {
            return (_context.BankSlips?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
