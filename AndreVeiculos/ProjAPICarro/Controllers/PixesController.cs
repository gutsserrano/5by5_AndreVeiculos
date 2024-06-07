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
    public class PixesController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public PixesController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Pixes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pix>>> GetPixes()
        {
          if (_context.Pixes == null)
          {
              return NotFound();
          }
            return await _context.Pixes.Include(pt => pt.PixType).ToListAsync();
        }

        // GET: api/Pixes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pix>> GetPix(int id)
        {
          if (_context.Pixes == null)
          {
              return NotFound();
          }
            var pix = await _context.Pixes.Include(pt => pt.PixType).FirstOrDefaultAsync();

            if (pix == null)
            {
                return NotFound();
            }

            return pix;
        }

        // PUT: api/Pixes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPix(int id, Pix pix)
        {
            if (id != pix.Id)
            {
                return BadRequest();
            }

            _context.Entry(pix).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PixExists(id))
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

        // POST: api/Pixes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pix>> PostPix(PixDTO pixDTO)
        {
            /*if (_context.Pixes == null)
            {
                return Problem("Entity set 'ProjAPICarroContext.Pixes'  is null.");
            }*/

            /*CarOperation carOp = new(carOperationDTO);
            carOp.Car = await _context.Car.FindAsync(carOp.Car.Plate);
            carOp.Operation = await _context.Operations.FindAsync(carOp.Operation.Id);*/

            Pix pix = new(pixDTO);
            pix.PixType = await _context.PixTypes.FindAsync(pix.PixType.Id);

            _context.Pixes.Add(pix);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPix", new { id = pix.Id }, pix);
        }

        // DELETE: api/Pixes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePix(int id)
        {
            if (_context.Pixes == null)
            {
                return NotFound();
            }
            var pix = await _context.Pixes.FindAsync(id);
            if (pix == null)
            {
                return NotFound();
            }

            _context.Pixes.Remove(pix);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PixExists(int id)
        {
            return (_context.Pixes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
