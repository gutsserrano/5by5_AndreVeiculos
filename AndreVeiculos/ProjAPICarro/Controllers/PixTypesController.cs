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
    public class PixTypesController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public PixTypesController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/PixTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PixType>>> GetPixTypes()
        {
          if (_context.PixTypes == null)
          {
              return NotFound();
          }
            return await _context.PixTypes.ToListAsync();
        }

        // GET: api/PixTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PixType>> GetPixType(int id)
        {
          if (_context.PixTypes == null)
          {
              return NotFound();
          }
            var pixType = await _context.PixTypes.FindAsync(id);

            if (pixType == null)
            {
                return NotFound();
            }

            return pixType;
        }

        // PUT: api/PixTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPixType(int id, PixType pixType)
        {
            if (id != pixType.Id)
            {
                return BadRequest();
            }

            _context.Entry(pixType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PixTypeExists(id))
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

        // POST: api/PixTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PixType>> PostPixType(PixType pixType)
        {
          if (_context.PixTypes == null)
          {
              return Problem("Entity set 'ProjAPICarroContext.PixTypes'  is null.");
          }
            _context.PixTypes.Add(pixType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPixType", new { id = pixType.Id }, pixType);
        }

        // DELETE: api/PixTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePixType(int id)
        {
            if (_context.PixTypes == null)
            {
                return NotFound();
            }
            var pixType = await _context.PixTypes.FindAsync(id);
            if (pixType == null)
            {
                return NotFound();
            }

            _context.PixTypes.Remove(pixType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PixTypeExists(int id)
        {
            return (_context.PixTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
