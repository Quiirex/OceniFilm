using Microsoft.EntityFrameworkCore;
using Seznami.API.Models;

namespace Seznami.API.Data;

public class SeznamiFilmovDbContext : DbContext
{
    public SeznamiFilmovDbContext(DbContextOptions<SeznamiFilmovDbContext> options) : base(options)
    {
    }

    public DbSet<SeznamFilmov> SeznamiFilmov { get; set; }
}