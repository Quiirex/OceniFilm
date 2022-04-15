using Seznami.API.Models;

namespace Seznami.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<SeznamiFilmovDbContext>());
    }

    private static void SeedData(SeznamiFilmovDbContext database)
    {
        if (!database.SeznamiFilmov.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding data...", DateTime.Now);

            database.SeznamiFilmov.AddRange(
                new SeznamFilmov
                {
                    Uporabnik = new Uporabnik {UporabniskoIme = "Janez123"},
                    NazivSeznama = "Favoriti",
                    Filmi = new List<Film>
                    {
                        new()
                        {
                            Naslov = "The Batman"
                        },
                        new()
                        {
                            Naslov = "Spider-Man: Homecoming"
                        },
                        new()
                        {
                            Naslov = "Titanic"
                        }
                    }
                },
                new SeznamFilmov
                {
                    Uporabnik = new Uporabnik {UporabniskoIme = "Marjan123"},
                    NazivSeznama = "Za kasneje",
                    Filmi = new List<Film>
                    {
                        new()
                        {
                            Naslov = "The Batman"
                        },
                        new()
                        {
                            Naslov = "Spider-Man: Homecoming"
                        },
                        new()
                        {
                            Naslov = "Titanic"
                        }
                    }
                },
                new SeznamFilmov
                {
                    Uporabnik = new Uporabnik {UporabniskoIme = "Bojan123"},
                    NazivSeznama = "Poglej",
                    Filmi = new List<Film>
                    {
                        new()
                        {
                            Naslov = "The Batman"
                        },
                        new()
                        {
                            Naslov = "Spider-Man: Homecoming"
                        },
                        new()
                        {
                            Naslov = "Titanic"
                        }
                    }
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