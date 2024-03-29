﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ocenjevanje.API.Data;
using Ocenjevanje.API.Models;

namespace Ocenjevanje.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OcenaController : ControllerBase
{
    private readonly OcenjevanjeDbContext _context;

    public OcenaController(OcenjevanjeDbContext context)
    {
        _context = context;
    }

    // GET: api/Ocena
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ocena>>> GetOcene()
    {
        return await _context.Ocene.Include(w => w.Ocenjevalec).Include(w => w.OcenjenFilm).ToListAsync();
    }

    // GET: api/Ocena/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Ocena>> GetOcena(int id)
    {
        Ocena? ocena = await _context.Ocene.Include(w => w.Ocenjevalec).Include(w => w.OcenjenFilm).SingleOrDefaultAsync(u => u.Id == id);

        if (ocena == null)
        {
            return NotFound();
        }

        return ocena;
    }

    // GET: api/Ocena/5
    [HttpGet("/poFilmuInUporabniku/{naslovFilma}/{prikaznoIme}")]
    public async Task<ActionResult<Ocena>> GetOcenaByFilmAndUser(string naslovFilma, string prikaznoIme)
    {
        Ocena? ocena = await _context.Ocene.Include(w => w.Ocenjevalec).Include(w => w.OcenjenFilm).Where(o => o.OcenjenFilm.Naslov == naslovFilma && o.Ocenjevalec.PrikaznoIme == prikaznoIme).FirstOrDefaultAsync();

        if (ocena == null)
        {
            return NotFound();
        }

        return ocena;
    }

    // PUT: api/Ocena/5
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> PutOcena(Ocena ocena)
    {
        Ocena? fetchedOcena = await _context.Ocene.Include(w => w.Ocenjevalec).Include(w => w.OcenjenFilm).Where(o => o.OcenjenFilm.Naslov == ocena.OcenjenFilm.Naslov && o.Ocenjevalec.PrikaznoIme == ocena.Ocenjevalec.PrikaznoIme).FirstOrDefaultAsync();

        if (fetchedOcena == null)
        {
            return NotFound();
        }

        fetchedOcena.Vrednost = ocena.Vrednost;
        _context.Entry(fetchedOcena).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }

        return Ok();
    }

    // POST: api/Ocena
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ocena>> PostOcena(Ocena ocena)
    {
        _context.Ocene.Add(ocena);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetOcena", new { id = ocena.Id }, ocena);
    }

    // DELETE: api/Ocena/5
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteOcena(int id)
    {
        Ocena? ocena = await _context.Ocene.FindAsync(id);
        if (ocena == null)
        {
            return NotFound();
        }

        _context.Ocene.Remove(ocena);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}