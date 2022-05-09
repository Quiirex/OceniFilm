using Microsoft.EntityFrameworkCore;
using Videoteka.API.Models;

namespace Videoteka.API.Data;

public class VideotekaDbContext : DbContext
{
    public VideotekaDbContext(DbContextOptions<VideotekaDbContext> options) : base(options)
    {
    }

    public DbSet<Film> Filmi { get; set; }
}