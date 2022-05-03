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
    public class MovieController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public MovieController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var response = new Response();
            var movie = await _context.Movies.ToListAsync();
            response.StatusCodes = 404;
            response.StatusDescription = "Unsuccessful";
            if (movie.Count > 0 && movie != null)
            {
                response.StatusCodes = 200;
                response.StatusDescription = "Successfully retrieve everything!!! :)";
                for (int i = 0; i < movie.Count; ++i)
                {
                    response.Movies.Add(movie[i]);
                }
            }

            return Ok(response);
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var response = new Response();
            var movie = await _context.Movies.FindAsync(id);
            response.StatusCodes = 404;
            response.StatusDescription = "Cannot retrieve a theatre. Doesnot exist :(";
            if (movie != null)
            {
                response.StatusCodes = 200;
                response.StatusDescription = "Successfully retrieve everything!!! :)";
                response.Movies.Add(movie);
            }

            return Ok(response);
        }

        // PUT: api/Movie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            var response = new Response();
            response.StatusDescription = "Updated successfully. :)";
            response.StatusCodes = 200;
            if (id != movie.MovieId)
            {
                //return BadRequest();
                response.StatusDescription = "Id passed and body id doesnot match. Its a bad request. :(";
                response.StatusCodes = 404;
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            var response = new Response();
            response.StatusCodes = 200;
            response.StatusDescription = "Added successfully :)";
            _context.Movies.Add(movie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieExists(movie.MovieId))
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

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            var response = new Response();
            response.StatusCodes = 404;
            response.StatusDescription = "Movie doesnot exist at all. :(";
            
            if (movie != null)
            {
                //return NotFound();
                response.StatusCodes = 200;
                response.StatusDescription = "Deleted successfully :)";
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }

            return Ok(response);
            //return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
