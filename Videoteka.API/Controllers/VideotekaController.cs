using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Videoteka.API.Data;
using Videoteka.API.Models;

namespace Videoteka.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideotekaController : ControllerBase
{
    private readonly VideotekaDbContext _context;

    public VideotekaController(VideotekaDbContext context)
    {
        _context = context;
    }

    // GET: api/Videoteka
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Film>>> GetFilmi()
    {
        return await _context.Filmi.ToListAsync();
    }

    // GET: api/Videoteka/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Film>> GetFilm(int id)
    {
        Film? film = await _context.Filmi.FindAsync(id);

        if (film == null)
        {
            return NotFound();
        }

        return film;
    }

    // GET: api/Videoteka/5
    [HttpGet("film/{naslovFilma}")]
    public async Task<ActionResult<Film>> GetFilmByNaslov(string naslovFilma)
    {
        Film? film = await _context.Filmi.FirstOrDefaultAsync(film => film.Naslov == naslovFilma);

        if (film == null)
        {
            return NotFound();
        }

        return film;
    }

    // PUT: api/Videoteka/5
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutFilm(int id, Film film)
    {
        if (id != film.Id)
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

            throw;
        }

        return NoContent();
    }

    // POST: api/Videoteka
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Film>> PostFilm(Film film)
    {
        _context.Filmi.Add(film);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFilm", new { id = film.Id }, film);
    }

    // DELETE: api/Videoteka/5
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteFilm(int id)
    {
        Film? film = await _context.Filmi.FindAsync(id);
        if (film == null)
        {
            return NotFound();
        }

        _context.Filmi.Remove(film);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FilmExists(int id)
    {
        return _context.Filmi.Any(e => e.Id == id);
    }
}