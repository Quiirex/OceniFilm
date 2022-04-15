using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seznami.API.Data;
using Seznami.API.Models;

namespace Seznami.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeznamFilmovController : ControllerBase
{
    private readonly SeznamiFilmovDbContext _context;

    public SeznamFilmovController(SeznamiFilmovDbContext context)
    {
        _context = context;
    }

    // GET: api/SeznamFilmov
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SeznamFilmov>>> GetSeznamiFilmov()
    {
        return await _context.SeznamiFilmov.ToListAsync();
    }

    // GET: api/SeznamFilmov/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SeznamFilmov>> GetSeznamFilmov(int id)
    {
        var seznamFilmov = await _context.SeznamiFilmov.FindAsync(id);

        if (seznamFilmov == null) return NotFound();

        return seznamFilmov;
    }

    // PUT: api/SeznamFilmov/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSeznamFilmov(int id, SeznamFilmov seznamFilmov)
    {
        if (id != seznamFilmov.Id) return BadRequest();

        _context.Entry(seznamFilmov).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SeznamFilmovExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/SeznamFilmov
    [HttpPost]
    public async Task<ActionResult<SeznamFilmov>> PostSeznamFilmov(SeznamFilmov seznamFilmov)
    {
        _context.SeznamiFilmov.Add(seznamFilmov);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSeznamFilmov", new {id = seznamFilmov.Id}, seznamFilmov);
    }

    // DELETE: api/SeznamFilmov/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSeznamFilmov(int id)
    {
        var seznamFilmov = await _context.SeznamiFilmov.FindAsync(id);
        if (seznamFilmov == null) return NotFound();

        _context.SeznamiFilmov.Remove(seznamFilmov);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool SeznamFilmovExists(int id)
    {
        return _context.SeznamiFilmov.Any(e => e.Id == id);
    }
}