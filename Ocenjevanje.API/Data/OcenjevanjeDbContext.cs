using Microsoft.EntityFrameworkCore;
using Ocenjevanje.API.Models;

namespace Ocenjevanje.API.Data;

public class OcenjevanjeDbContext : DbContext
{
    public OcenjevanjeDbContext(DbContextOptions<OcenjevanjeDbContext> options) : base(options)
    {
    }

    public DbSet<Ocena> Ocene { get; set; }
}