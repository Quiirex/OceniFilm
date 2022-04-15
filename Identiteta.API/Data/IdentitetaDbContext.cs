using Identiteta.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Identiteta.API.Data;

public class IdentitetaDbContext : DbContext
{
    public IdentitetaDbContext(DbContextOptions<IdentitetaDbContext> options) : base(options)
    {
    }

    public DbSet<Uporabnik> Uporabniki { get; set; }
}