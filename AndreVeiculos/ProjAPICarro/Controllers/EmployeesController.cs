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
    public class EmployeesController : ControllerBase
    {
        private readonly ProjAPICarroContext _context;

        public EmployeesController(ProjAPICarroContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet("{type}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees(string type)
        {
            if(type == "framework")
            {
                if (_context.Employees == null)
                {
                    return NotFound();
                }
                return await _context.Employees.ToListAsync();
            }
            else if (type == "dapper")
            {
                EmployeeService employeeService = new();
                return employeeService.GetAll();
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/Employees/5
        [HttpGet("{type}/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string type, string id)
        {
            if(type == "framework")
            {
                if (_context.Employees == null)
                {
                    return NotFound();
                }
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Document == id);

                if (employee == null)
                {
                    return NotFound();
                }

                return employee;
            }
            else if (type == "dapper")
            {
                EmployeeService employeeService = new();
                var employee = employeeService.Get(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return employee;
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.Document)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{type}")]
        public async Task<ActionResult<Employee>> PostEmployee(string type, Employee employee)
        {
            if(type == "framework")
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEmployee", new { id = employee.Document }, employee);
            }
            else if (type == "dapper")
            {
                EmployeeService employeeService = new();
                if (employeeService.Insert(employee))
                {
                    return CreatedAtAction("GetEmployee", new { type = type, id = employee.Document }, employee);
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

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(string id)
        {
            return (_context.Employees?.Any(e => e.Document == id)).GetValueOrDefault();
        }
    }
}
