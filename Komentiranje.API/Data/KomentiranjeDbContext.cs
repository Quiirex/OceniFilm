using Komentiranje.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Komentiranje.API.Data;

public class KomentiranjeDbContext : DbContext
{
    public KomentiranjeDbContext(DbContextOptions<KomentiranjeDbContext> options) : base(options)
    {
    }

    public DbSet<Komentar> Komentarji { get; set; }
    public DbSet<Komentator> Komentatorji { get; set; }
}