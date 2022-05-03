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
            var response = new Response();
            var theatre = await _context.Theatres.Include(theater => theater.Movies).ToListAsync();
            response.StatusCodes = 404;
            response.StatusDescription = "Unsuccessful";
            if (theatre.Count > 0 && theatre != null)
            {
                response.StatusCodes = 200;
                response.StatusDescription = "Successfully retrieve everything!!! :)";
                for (int i = 0; i < theatre.Count; ++i)
                {
                    response.Theatres.Add(theatre[i]);
                }
            }

            return Ok(response);

        }

        // GET: api/Theatre/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Theatre>> GetTheatre(int id)
        {
            var response = new Response();
            var theatre = await _context.Theatres.Include(theatre => theatre.Movies).SingleOrDefaultAsync(theatre => theatre.TheatreId == id);
            response.StatusCodes = 404;
            response.StatusDescription = "Cannot retrieve a theatre. Doesnot exist :(";
            if (theatre != null)
            {
                response.StatusCodes = 200;
                response.StatusDescription = "Successfully retrieve everything!!! :)";
                response.Theatres.Add(theatre);
            }

            return Ok(response);

        }

        // PUT: api/Theatre/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheatre(int id, Theatre theatre)
        {
            var response = new Response();
            response.StatusDescription = "Updated successfully. :)";
            response.StatusCodes = 200;
            if (id != theatre.TheatreId)
            {
                //return BadRequest();
                response.StatusDescription = "Id passed and body id doesnot match. Its a bad request. :(";
                response.StatusCodes = 404;
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
                    //return NotFound();
                    response.StatusDescription = "Id passed doesnot exists at all. :(";
                    response.StatusCodes = 404;
                    return Ok(response);
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return Ok(response);
        }

        // POST: api/Theatre
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Theatre>> PostTheatre(Theatre theatre)
        {
            var response = new Response();
            response.StatusCodes = 200;
            response.StatusDescription = "Added successfully :)";
            _context.Theatres.Add(theatre);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TheatreExists(theatre.TheatreId))
                {
                    response.StatusCodes = 404;
                    response.StatusDescription = "Cannot add. Already exists :(";
                }
                else
                {
                    throw;
                }
            }

            return Ok(response);
        }

        // DELETE: api/Theatre/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheatre(int id)
        {
            var theatre = await _context.Theatres.FindAsync(id);
            var response = new Response();

            response.StatusCodes = 404;
            response.StatusDescription = "Theatre doesnot exist at all. :(";

          
            if (theatre != null)
            {
                response.StatusDescription = "Deleted successfully :)";
                response.StatusCodes = 200;
                //return NotFound();
                _context.Theatres.Remove(theatre);
                await _context.SaveChangesAsync();
            }

            //return NoContent();
            return Ok(response);
        }

        private bool TheatreExists(int id)
        {
            return _context.Theatres.Any(e => e.TheatreId == id);
        }
    }
}
