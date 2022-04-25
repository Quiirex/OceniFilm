using Igralci.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Igralci.API.Data;

public class IgralciDbContext : DbContext
{
    public IgralciDbContext(DbContextOptions<IgralciDbContext> options) : base(options)
    {
    }

    public DbSet<Igralec> Igralci { get; set; }
}
