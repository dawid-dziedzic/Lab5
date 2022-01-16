using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zad4.Model;
using zad4.Models;

namespace zad4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly DataContext _context;

        public FilmsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Films
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> Getfilmy()
        {
            var x = _context.filmy.ToList();
            if (x.Count() < 4)
            {
                _context.filmy.AddRange(
                    new Film { Tytul = "test1", Kraj = "Polskie", Kategoria = "test1", Rok = DateTime.Now, Koszt=100 },
                    new Film { Tytul = "test2", Kraj = "Polskie", Kategoria = "test2", Rok = DateTime.Now, Koszt = 100 },
                    new Film { Tytul = "test3", Kraj = "Polskie", Kategoria = "test3", Rok = DateTime.Now, Koszt = 100 },
                    new Film { Tytul = "test4", Kraj = "Polskie", Kategoria = "test4", Rok = DateTime.Now, Koszt = 100 });

                _context.SaveChanges();
            }
            return await _context.filmy.ToListAsync();
        }

        // GET: api/Films/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _context.filmy.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            return film;
        }

        // PUT: api/Films/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.id)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
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

        // POST: api/Films
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilm(Film film)
        {
            _context.filmy.Add(film);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.id }, film);
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _context.filmy.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.filmy.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmExists(int id)
        {
            return _context.filmy.Any(e => e.id == id);
        }
    }
}
