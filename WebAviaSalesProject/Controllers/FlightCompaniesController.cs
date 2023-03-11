using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAviaSalesProject.Database;
using WebAviaSalesProject.Models;

namespace WebAviaSalesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightCompaniesController : ControllerBase
    {
        private readonly AviaSalesContext _context;

        public FlightCompaniesController(AviaSalesContext context)
        {
            _context = context;
        }

        // GET: api/FlightCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightCompany>>> GetFlightCompanys()
        {
            return await _context.FlightCompanys.ToListAsync();
        }

        // GET: api/FlightCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightCompany>> GetFlightCompany(int id)
        {
            var flightCompany = await _context.FlightCompanys.FindAsync(id);

            if (flightCompany == null)
            {
                return NotFound();
            }

            return flightCompany;
        }

        // PUT: api/FlightCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightCompany(int id, FlightCompany flightCompany)
        {
            if (id != flightCompany.FlightCompanysId)
            {
                return BadRequest();
            }

            _context.Entry(flightCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightCompanyExists(id))
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

        // POST: api/FlightCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightCompany>> PostFlightCompany(FlightCompany flightCompany)
        {
            _context.FlightCompanys.Add(flightCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightCompany", new { id = flightCompany.FlightCompanysId }, flightCompany);
        }

        // DELETE: api/FlightCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightCompany(int id)
        {
            var flightCompany = await _context.FlightCompanys.FindAsync(id);
            if (flightCompany == null)
            {
                return NotFound();
            }

            _context.FlightCompanys.Remove(flightCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightCompanyExists(int id)
        {
            return _context.FlightCompanys.Any(e => e.FlightCompanysId == id);
        }
    }
}
