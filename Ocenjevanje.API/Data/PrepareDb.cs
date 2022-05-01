using Ocenjevanje.API.Models;

namespace Ocenjevanje.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app)
    {
        using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<OcenjevanjeDbContext>());
    }

    private static void SeedData(OcenjevanjeDbContext database)
    {
        if (!database.Ocene.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding data...", DateTime.Now);

            database.Ocene.AddRange(
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
            database.SaveChanges();
        }
        else
        {
            Console.WriteLine("[PrepareDb] Data is present in the database");
        }
    }
}