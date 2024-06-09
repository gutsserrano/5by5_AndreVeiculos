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
    public class CarsController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public CarsController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet("{type}")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCar(string type)
        {
            if (type == "framework")
            {
                if (_context.Car == null)
                {
                    return NotFound();
                }
                return await _context.Car.ToListAsync();
            }
            else if (type == "dapper")
            {
                CarService carService = new CarService();
                return carService.GetAll();
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/Cars/5
        [HttpGet("{type}/{id}")]
        public async Task<ActionResult<Car>> GetCar(string type, string id)
        {
            if(type == "framework")
            {
                if (_context.Car == null)
                {
                    return NotFound();
                }
                var car = await _context.Car.FindAsync(id);

                if (car == null)
                {
                    return NotFound();
                }

                return car;
            }
            else if(type == "dapper")
            {
                CarService carService = new CarService();
                var car = carService.Get(id);
                if (car == null)
                {
                    return NotFound();
                }
                return car;
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(string id, Car car)
        {
            if (id != car.Plate)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars/{type}
        // the type parameter is used to determine which method to use to insert the car
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{type}")]
        public async Task<ActionResult<Car>> PostCar(string type,Car car)
        {
            if(type == "framework")
            {
                if (_context.Car == null)
                {
                    return Problem("Entity set 'ProjAPICarroContext.Car'  is null.");
                }
                _context.Car.Add(car);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (CarExists(car.Plate))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetCar", new { id = car.Plate }, car);
            }
            else if(type == "dapper"  )
            {
                CarService carService = new CarService();
                if (carService.Insert(new List<Car> { car }))
                {
                    return CreatedAtAction("GetCar", new { type = type, id = car.Plate }, car);
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

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(string id)
        {
            if (_context.Car == null)
            {
                return NotFound();
            }
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(string id)
        {
            return (_context.Car?.Any(e => e.Plate == id)).GetValueOrDefault();
        }
    }
}
