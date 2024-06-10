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
    public class ClientsController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public ClientsController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet("{type}")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients(string type)
        {
            if(type == "framework")
            {
                if (_context.Clients == null)
                {
                    return NotFound();
                }
                return await _context.Clients.Include(a => a.Address).ToListAsync();
            }
            else if (type == "dapper")
            {
                ClientService clientService = new();
                return clientService.GetAll();
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/Clients/5
        [HttpGet("{type}/{id}")]
        public async Task<ActionResult<Client>> GetClient(string type, string id)
        {
            if(type == "framework")
            {
                if (_context.Clients == null)
                {
                    return NotFound();
                }
                var client = await _context.Clients.Include(a => a.Address).Where(c => c.Document == id).FirstOrDefaultAsync();

                if (client == null)
                {
                    return NotFound();
                }

                return client;
            }
            else if (type == "dapper")
            {
                ClientService clientService = new();
                var client = clientService.Get(id);
                if (client == null)
                {
                    return NotFound();
                }
                return client;
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(string id, Client client)
        {
            if (id != client.Document)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{type}")]
        public async Task<ActionResult<Client>> PostClient(string type, Client client)
        {
            if(type == "framework")
            {
                if (_context.Clients == null)
                {
                    return Problem("Entity set 'ProjAPICarroContext.Clients'  is null.");
                }
                _context.Clients.Add(client);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (ClientExists(client.Document))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetClient", new { id = client.Document }, client);
            }
            else if(type == "dapper")
            {
                ClientService clientService = new();
                if (clientService.Insert(client))
                {
                    return CreatedAtAction("GetClient", new { type = type, id = client.Document }, client);
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

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(string id)
        {
            return (_context.Clients?.Any(e => e.Document == id)).GetValueOrDefault();
        }
    }
}
