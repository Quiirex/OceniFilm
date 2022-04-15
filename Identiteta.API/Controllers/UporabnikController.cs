﻿#nullable disable
using Identiteta.API.Data;
using Identiteta.API.Models;
using Identiteta.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identiteta.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UporabnikController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly IdentitetaDbContext _context;

    public UporabnikController(IdentitetaDbContext context, AuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    // GET: api/Uporabnik
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Uporabnik>>> GetUporabniki()
    {
        return await _context.Uporabniki.ToListAsync();
    }

    // GET: api/Uporabnik/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Uporabnik>> GetUporabnik(string id)
    {
        var uporabnik = await _context.Uporabniki.FindAsync(id);

        if (uporabnik == null) return NotFound();

        return Ok(uporabnik);
    }

    // PUT: api/Uporabnik/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUporabnik(string id, [FromBody] Uporabnik uporabnik)
    {
        if (id != uporabnik.Id) return BadRequest();

        _context.Entry(uporabnik).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UporabnikExists(id))
                return NotFound();
            throw;
        }

        return Ok(uporabnik);
    }

    // POST api/Uporabnik/login
    [HttpPost("~/login")]
    public ActionResult<Uporabnik> PrijavaUporabnika([FromBody] UporabnikPrijava uporabnik)
    {
        var iskaniUporabnik = _context.Uporabniki.Single(u => u.Email == uporabnik.Email);

        if (!_authService.VerifyPassword(uporabnik.Geslo, iskaniUporabnik.Geslo, iskaniUporabnik.Sol))
            return Unauthorized();

        var generiranToken = _authService.GenerateJwtToken(iskaniUporabnik);
        return Ok(new {Token = generiranToken});
    }

    // POST: api/Uporabnik/register
    [HttpPost("~/register")]
    public async Task<ActionResult<Uporabnik>> RegistracijaUporabnika([FromBody] Uporabnik noviUporabnik)
    {
        noviUporabnik = _authService.HashPassword(noviUporabnik);
        _context.Uporabniki.Add(noviUporabnik);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUporabnik", new {id = noviUporabnik.Id}, noviUporabnik);
    }

    // DELETE: api/Uporabnik/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUporabnik(string id)
    {
        var uporabnik = await _context.Uporabniki.FindAsync(id);
        if (uporabnik == null) return NotFound();

        _context.Uporabniki.Remove(uporabnik);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UporabnikExists(string id)
    {
        return _context.Uporabniki.Any(uporabnik => uporabnik.Id == id);
    }
}