using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<ActionResult<IEnumerable<SeznamFilmov>>> GetSeznamiFilmov()
    {
        return await _context.SeznamiFilmov.Include(w => w.Filmi).Include(w => w.Uporabnik).ToListAsync();
    }

    // GET: api/SeznamFilmov/5
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<SeznamFilmov>> GetSeznamFilmov(int id)
    {
        SeznamFilmov? seznamFilmov = await _context.SeznamiFilmov.Include(w => w.Filmi).Include(w => w.Uporabnik).SingleOrDefaultAsync(u => u.Id == id);

        if (seznamFilmov == null)
        {
            return NotFound();
        }

        return seznamFilmov;
    }

    // GET: api/SeznamFilmov/5
    [HttpGet("/poUporabniku/{prikaznoIme}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<SeznamFilmov>>> GetSeznamFilmovByUser(string prikaznoIme)
    {
        IEnumerable<SeznamFilmov> seznamFilmov = await _context.SeznamiFilmov.Include(w => w.Filmi).Include(w => w.Uporabnik).Where(s => s.Uporabnik.PrikaznoIme == prikaznoIme).ToListAsync();

        if (seznamFilmov == null)
        {
            return NotFound();
        }

        return Ok(seznamFilmov);
    }

    // PUT: api/SeznamFilmov/5
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> PutSeznamFilmov(SeznamFilmov seznamFilmov)
    {
        _context.Entry(seznamFilmov).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }

        return NoContent();
    }

    // POST: api/SeznamFilmov
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<SeznamFilmov>> PostSeznamFilmov(SeznamFilmov seznamFilmov)
    {
        _context.SeznamiFilmov.Add(seznamFilmov);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSeznamFilmov", new { id = seznamFilmov.Id }, seznamFilmov);
    }

    [HttpPost("/odstraniSeznamFilmov")]
    [Authorize]
    public async Task<IActionResult> DeleteSeznamFilmov(SeznamFilmov seznamFilmov)
    {
        SeznamFilmov? fetchedSeznamFilmov = await _context.SeznamiFilmov.Include(w => w.Filmi).Include(w => w.Uporabnik).Where(s => s.NazivSeznama == seznamFilmov.NazivSeznama && s.Uporabnik.PrikaznoIme == seznamFilmov.Uporabnik.PrikaznoIme).FirstOrDefaultAsync();

        if (fetchedSeznamFilmov == null)
        {
            return NotFound();
        }

        _context.SeznamiFilmov.Remove(fetchedSeznamFilmov);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}