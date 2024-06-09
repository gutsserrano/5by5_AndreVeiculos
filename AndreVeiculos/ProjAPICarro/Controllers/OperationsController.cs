using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAPICarro.Data;
using Services;

namespace ProjAPICarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public OperationsController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Operations
        [HttpGet("{type}")]
        public async Task<ActionResult<IEnumerable<Operation>>> GetOperations(string type)
        {
            if(type == "framework")
            {
                if (_context.Operations == null)
                {
                    return NotFound();
                }
                return await _context.Operations.ToListAsync();
            }
            else if(type == "dapper")
            {
                OperationService operationService = new OperationService();
                return operationService.GetAll();
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/Operations/5
        [HttpGet("{type}/{id}")]
        public async Task<ActionResult<Operation>> GetOperation(string type, int id)
        {
            if(type == "framework")
            {
                if (_context.Operations == null)
                {
                    return NotFound();
                }
                var operation = await _context.Operations.FindAsync(id);

                if (operation == null)
                {
                    return NotFound();
                }

                return operation;
            }
            else if(type == "dapper")
            {
                OperationService operationService = new OperationService();
                var operation = operationService.Get(id);
                if (operation == null)
                {
                    return NotFound();
                }

                return operation;
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Operations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperation(int id, Operation operation)
        {
            if (id != operation.Id)
            {
                return BadRequest();
            }

            _context.Entry(operation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationExists(id))
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

        // POST: api/Operations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{type}")]
        public async Task<ActionResult<Operation>> PostOperation(string type, Operation operation)
        {
            if(type == "framework")
            {
                if (_context.Operations == null)
                {
                    return Problem("Entity set 'ProjAPICarroContext.Operations'  is null.");
                }
                _context.Operations.Add(operation);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetOperation", new { id = operation.Id }, operation);
            }
            else if(type == "dapper")
            {
                OperationService operationService = new OperationService();
                operationService.Insert(new List<Operation> { operation });
                return CreatedAtAction("GetOperation", new { type = type, id = operation.Id }, operation);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Operations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperation(int id)
        {
            if (_context.Operations == null)
            {
                return NotFound();
            }
            var operation = await _context.Operations.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }

            _context.Operations.Remove(operation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperationExists(int id)
        {
            return (_context.Operations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
