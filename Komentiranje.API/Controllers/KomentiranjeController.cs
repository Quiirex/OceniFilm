using Komentiranje.API.Data;
using Komentiranje.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Komentiranje.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KomentarController : ControllerBase
{
    private readonly KomentiranjeDbContext _context;

    public KomentarController(KomentiranjeDbContext context)
    {
        _context = context;
    }

    // GET: api/Komentar
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Komentar>>> GetKomentarji()
    {
        return await _context.Komentarji.Include(w => w.Komentator).Include(w => w.KomentiranFilm).ToListAsync();
    }

    // GET: api/Komentar/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Komentar>> GetKomentar(int id)
    {
        Komentar? komentar = await _context.Komentarji.Include(w => w.Komentator).Include(w => w.KomentiranFilm).SingleOrDefaultAsync(u => u.Id == id);

        if (komentar == null)
        {
            return NotFound();
        }   

        return komentar;
    }

    [HttpGet("/komentarjiPoFilmu/{naslovFilma}")]
    public async Task<ActionResult<IEnumerable<Komentar>>> GetKomentarjiByKomentiranFilm(string naslovFilma)
    {
        IEnumerable<Komentar> komentar = await _context.Komentarji.Include(w => w.Komentator).Include(w => w.KomentiranFilm).Where(k => k.KomentiranFilm.Naslov == naslovFilma).ToListAsync();

        if (komentar == null)
        {
            return NotFound();
        }

        return Ok(komentar);
    }

    // PUT: api/Komentar/5
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutKomentar(int id, Komentar komentar)
    {
        if (id != komentar.Id)
        {
            return BadRequest();
        }

        _context.Entry(komentar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!KomentarExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: api/Komentar
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Komentar>> PostKomentar(Komentar komentar)
    {
        _context.Komentarji.Add(komentar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetKomentar", new { id = komentar.Id }, komentar);
    }

    [HttpPost("/odstraniKomentar")]
    [Authorize]
    public async Task<IActionResult> DeleteKomentar(Komentar komentar)
    {
        Komentar? fetchedKomentar = await _context.Komentarji.Include(w => w.Komentator).Include(w => w.KomentiranFilm).Where(k => k.Komentator.PrikaznoIme == komentar.Komentator.PrikaznoIme && k.KomentiranFilm.Naslov == komentar.KomentiranFilm.Naslov  && k.Vsebina == komentar.Vsebina).FirstOrDefaultAsync();

        if (fetchedKomentar == null)
        {
            return NotFound();
        }

        _context.Komentarji.Remove(fetchedKomentar);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool KomentarExists(int id)
    {
        return _context.Komentarji.Any(e => e.Id == id);
    }
}