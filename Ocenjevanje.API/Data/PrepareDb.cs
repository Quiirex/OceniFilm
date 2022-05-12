using Microsoft.EntityFrameworkCore;
using Ocenjevanje.API.Models;

namespace Ocenjevanje.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app, bool useSQLServ)
    {
        using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<OcenjevanjeDbContext>(), useSQLServ);
    }

    private static void SeedData(OcenjevanjeDbContext dbContext, bool useSQLServ)
    {
        if (useSQLServ)
        {
            try
            {
                Console.WriteLine($"[PrepareDb] Attempting a database migration...");
                dbContext.Database.Migrate();
                Console.WriteLine($"[PrepareDb] Migration successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PrepareDb] Migration unsuccessful: {ex.Message}");
            }
        }

        if (!dbContext.Ocene.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding data...", DateTime.Now);

            dbContext.Ocene.AddRange(
                new Ocena
                {
                    Vrednost = 9,
                    DatumOcene = DateTime.Now,
                    OcenjenFilm = new OcenjenFilm { Naslov = "The Batman" },
                    Ocenjevalec = new Ocenjevalec { PrikaznoIme = "janezek12" }
                },
                new Ocena
                {
                    Vrednost = 8,
                    DatumOcene = DateTime.Now,
                    OcenjenFilm = new OcenjenFilm { Naslov = "Tenet" },
                    Ocenjevalec = new Ocenjevalec { PrikaznoIme = "janezek12" }
                },
                new Ocena
                {
                    Vrednost = 3,
                    DatumOcene = DateTime.Now,
                    OcenjenFilm = new OcenjenFilm { Naslov = "Dune" },
                    Ocenjevalec = new Ocenjevalec { PrikaznoIme = "janezek12" }
                }
            );
            dbContext.SaveChanges();
        }
        else
        {
            Console.WriteLine("[PrepareDb] Data is present in the database");
        }
    }
}