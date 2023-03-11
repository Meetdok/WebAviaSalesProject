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
    public class ServicesTicketsController : ControllerBase
    {
        private readonly AviaSalesContext _context;

        public ServicesTicketsController(AviaSalesContext context)
        {
            _context = context;
        }

        // GET: api/ServicesTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicesTicket>>> GetServicesTickets()
        {
            return await _context.ServicesTickets.ToListAsync();
        }

        // GET: api/ServicesTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesTicket>> GetServicesTicket(int id)
        {
            var servicesTicket = await _context.ServicesTickets.FindAsync(id);

            if (servicesTicket == null)
            {
                return NotFound();
            }

            return servicesTicket;
        }

        // PUT: api/ServicesTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicesTicket(int id, ServicesTicket servicesTicket)
        {
            if (id != servicesTicket.ServiceTicketsId)
            {
                return BadRequest();
            }

            _context.Entry(servicesTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesTicketExists(id))
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

        // POST: api/ServicesTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServicesTicket>> PostServicesTicket(ServicesTicket servicesTicket)
        {
            _context.ServicesTickets.Add(servicesTicket);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServicesTicketExists(servicesTicket.ServiceTicketsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServicesTicket", new { id = servicesTicket.ServiceTicketsId }, servicesTicket);
        }

        // DELETE: api/ServicesTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicesTicket(int id)
        {
            var servicesTicket = await _context.ServicesTickets.FindAsync(id);
            if (servicesTicket == null)
            {
                return NotFound();
            }

            _context.ServicesTickets.Remove(servicesTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicesTicketExists(int id)
        {
            return _context.ServicesTickets.Any(e => e.ServiceTicketsId == id);
        }
    }
}
