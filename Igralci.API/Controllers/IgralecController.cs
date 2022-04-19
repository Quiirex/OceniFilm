using Igralci.API.Data;
using Igralci.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Igralci.API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class IgralecController : ControllerBase
{
    private readonly IgralciDbContext _context;

    public IgralecController(IgralciDbContext context)
    {
        _context = context;
    }

    // GET: api/Igralec
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Igralec>>> GetIgralci()
    {
        return await _context.Igralci.ToListAsync();
    }

    // GET: api/Igralec/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Igralec>> GetIgralec(int id)
    {
        Igralec? igralec = await _context.Igralci.FindAsync(id);

        if (igralec == null)
        {
            return NotFound();
        }

        return igralec;
    }

    // PUT: api/Igralec/5
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutIgralec(int id, Igralec igralec)
    {
        if (id != igralec.Id)
        {
            return BadRequest();
        }

        _context.Entry(igralec).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IgralecExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: api/Igralec
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Igralec>> PostIgralec(Igralec igralec)
    {
        _context.Igralci.Add(igralec);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetIgralec", new { id = igralec.Id }, igralec);
    }

    // DELETE: api/Igralec/5
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteIgralec(int id)
    {
        Igralec? igralec = await _context.Igralci.FindAsync(id);
        if (igralec == null)
        {
            return NotFound();
        }

        _context.Igralci.Remove(igralec);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool IgralecExists(int id)
    {
        return _context.Igralci.Any(e => e.Id == id);
    }
}