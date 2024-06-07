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
    public class CarOperationsController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public CarOperationsController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/CarOperations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarOperation>>> GetCarOperations()
        {
          if (_context.CarOperations == null)
          {
              return NotFound();
          }
            return await _context.CarOperations.Include(c => c.Car).Include(o => o.Operation).ToListAsync();
        }

        // GET: api/CarOperations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarOperation>> GetCarOperation(int id)
        {
          if (_context.CarOperations == null)
          {
              return NotFound();
          }
            var carOperation = await _context.CarOperations.Include(c => c.Car).Include(o => o.Operation).Where(cp => cp.Id == id).SingleOrDefaultAsync(c => c.Id == id);

            if (carOperation == null)
            {
                return NotFound();
            }

            return carOperation;
        }

        // PUT: api/CarOperations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarOperation(int id, CarOperation carOperation)
        {
            if (id != carOperation.Id)
            {
                return BadRequest();
            }

            _context.Entry(carOperation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarOperationExists(id))
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

        // POST: api/CarOperations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarOperation>> PostCarOperation(CarOperationDTO carOperationDTO)
        {
            CarOperation carOp = new(carOperationDTO);
            carOp.Car = await _context.Car.FindAsync(carOp.Car.Plate);
            carOp.Operation = await _context.Operations.FindAsync(carOp.Operation.Id);

            _context.CarOperations.Add(carOp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarOperation", new { id = carOp.Id }, carOp);
        }

        // DELETE: api/CarOperations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarOperation(int id)
        {
            if (_context.CarOperations == null)
            {
                return NotFound();
            }
            var carOperation = await _context.CarOperations.FindAsync(id);
            if (carOperation == null)
            {
                return NotFound();
            }

            _context.CarOperations.Remove(carOperation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarOperationExists(int id)
        {
            return (_context.CarOperations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
