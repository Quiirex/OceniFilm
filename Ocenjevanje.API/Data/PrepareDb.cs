using Ocenjevanje.API.Models;

namespace Ocenjevanje.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
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
                    OcenjenFilm = new OcenjenFilm {Naslov = "The Batman"},
                    Ocenjevalec = new Ocenjevalec {UporabniskoIme = "Janez123"}
                },
                new Ocena
                {
                    Vrednost = 4,
                    DatumOcene = DateTime.Now,
                    OcenjenFilm = new OcenjenFilm {Naslov = "Spider-Man: Homecoming"},
                    Ocenjevalec = new Ocenjevalec {UporabniskoIme = "Janez123"}
                },
                new Ocena
                {
                    Vrednost = 8,
                    DatumOcene = DateTime.Now,
                    OcenjenFilm = new OcenjenFilm {Naslov = "Tenet"},
                    Ocenjevalec = new Ocenjevalec {UporabniskoIme = "Bojan123"}
                },
                new Ocena
                {
                    Vrednost = 3,
                    DatumOcene = DateTime.Now,
                    OcenjenFilm = new OcenjenFilm {Naslov = "Dune"},
                    Ocenjevalec = new Ocenjevalec {UporabniskoIme = "Bojan123"}
                },
                new Ocena
                {
                    Vrednost = 6,
                    DatumOcene = DateTime.Now,
                    OcenjenFilm = new OcenjenFilm {Naslov = "Iron Man"},
                    Ocenjevalec = new Ocenjevalec {UporabniskoIme = "Marjan123"}
                },
                new Ocena
                {
                    Vrednost = 1,
                    DatumOcene = DateTime.Now,
                    OcenjenFilm = new OcenjenFilm {Naslov = "Titanic"},
                    Ocenjevalec = new Ocenjevalec {UporabniskoIme = "Marjan123"}
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