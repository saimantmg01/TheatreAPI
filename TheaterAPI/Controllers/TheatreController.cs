#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheaterAPI.Models;

namespace TheaterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public TheatreController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Theatre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theatre>>> GetTheatres()
        {
            //returns with children
            return await _context.Theatres.Include(theater => theater.Movies).ToListAsync();
        }

        // GET: api/Theatre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Theatre>> GetTheatre(int id)
        {
            //returns also the  children
            var theatre = await _context.Theatres.Include(theatre => theatre.Movies).SingleOrDefaultAsync(theatre => theatre.TheatreId == id);

            if (theatre == null)
            {
                return NotFound();
            }

            return theatre;
        }

        // PUT: api/Theatre/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheatre(int id, Theatre theatre)
        {
            if (id != theatre.TheatreId)
            {
                return BadRequest();
            }

            _context.Entry(theatre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheatreExists(id))
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

        // POST: api/Theatre
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Theatre>> PostTheatre(Theatre theatre)
        {
            _context.Theatres.Add(theatre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTheatre", new { id = theatre.TheatreId }, theatre);
        }

        // DELETE: api/Theatre/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheatre(int id)
        {
            var theatre = await _context.Theatres.FindAsync(id);
            if (theatre == null)
            {
                return NotFound();
            }

            _context.Theatres.Remove(theatre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TheatreExists(int id)
        {
            return _context.Theatres.Any(e => e.TheatreId == id);
        }
    }
}
