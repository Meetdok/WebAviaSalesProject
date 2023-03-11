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
    public class AirplanesClassesController : ControllerBase
    {
        private readonly AviaSalesContext _context;

        public AirplanesClassesController(AviaSalesContext context)
        {
            _context = context;
        }

        // GET: api/AirplanesClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirplanesClass>>> GetAirplanesClasses()
        {
            return await _context.AirplanesClasses.ToListAsync();
        }

        // GET: api/AirplanesClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirplanesClass>> GetAirplanesClass(int id)
        {
            var airplanesClass = await _context.AirplanesClasses.FindAsync(id);

            if (airplanesClass == null)
            {
                return NotFound();
            }

            return airplanesClass;
        }

        // PUT: api/AirplanesClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplanesClass(int id, AirplanesClass airplanesClass)
        {
            if (id != airplanesClass.AirplaneClassId)
            {
                return BadRequest();
            }

            _context.Entry(airplanesClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplanesClassExists(id))
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

        // POST: api/AirplanesClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirplanesClass>> PostAirplanesClass(AirplanesClass airplanesClass)
        {
            _context.AirplanesClasses.Add(airplanesClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirplanesClass", new { id = airplanesClass.AirplaneClassId }, airplanesClass);
        }

        // DELETE: api/AirplanesClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirplanesClass(int id)
        {
            var airplanesClass = await _context.AirplanesClasses.FindAsync(id);
            if (airplanesClass == null)
            {
                return NotFound();
            }

            _context.AirplanesClasses.Remove(airplanesClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirplanesClassExists(int id)
        {
            return _context.AirplanesClasses.Any(e => e.AirplaneClassId == id);
        }
    }
}
