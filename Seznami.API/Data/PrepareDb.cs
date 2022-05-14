using Microsoft.EntityFrameworkCore;
using Seznami.API.Models;

namespace Seznami.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app, bool useSQLServ)
    {
        using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<SeznamiFilmovDbContext>(), useSQLServ);
    }

    private static void SeedData(SeznamiFilmovDbContext dbContext, bool useSQLServ)
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

        if (!dbContext.SeznamiFilmov.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding data...", DateTime.Now);

            dbContext.SeznamiFilmov.AddRange(
                new SeznamFilmov
                {
                    Uporabnik = new Uporabnik { PrikaznoIme = "janezek12" },
                    NazivSeznama = "Favoriti",
                    Filmi = new List<Film>
                    {
                        new()
                        {
                            Naslov = "The Batman",
                            Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/the-batman_tgstxmov_480x.progressive.jpg?v=1641930817"
                        },
                        new()
                        {
                            Naslov = "Dune",
                            Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/dune_axfdsg2v_480x.progressive.jpg?v=1635262101"
                        },
                        new()
                        {
                            Naslov = "Don't Look Up",
                            Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/dont-look-up_xqrmuoe4_480x.progressive.jpg?v=1645647487"
                        }
                    }
                },
                new SeznamFilmov
                {
                    Uporabnik = new Uporabnik { PrikaznoIme = "janezek12" },
                    NazivSeznama = "Za kasneje",
                    Filmi = new List<Film>
                    {
                        new()
                        {
                            Naslov = "The Batman",
                            Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/the-batman_tgstxmov_480x.progressive.jpg?v=1641930817"
                        },
                        new()
                        {
                            Naslov = "Dune",
                            Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/dune_axfdsg2v_480x.progressive.jpg?v=1635262101"
                        },
                        new()
                        {
                            Naslov = "Don't Look Up",
                            Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/dont-look-up_xqrmuoe4_480x.progressive.jpg?v=1645647487"
                        }
                    }
                },
                new SeznamFilmov
                {
                    Uporabnik = new Uporabnik { PrikaznoIme = "janezek12" },
                    NazivSeznama = "Poglej",
                    Filmi = new List<Film>
                    {
                        new()
                        {
                            Naslov = "The Batman",
                            Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/the-batman_tgstxmov_480x.progressive.jpg?v=1641930817"
                        },
                        new()
                        {
                            Naslov = "Dune",
                            Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/dune_axfdsg2v_480x.progressive.jpg?v=1635262101"
                        },
                        new()
                        {
                            Naslov = "Don't Look Up",
                            Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/dont-look-up_xqrmuoe4_480x.progressive.jpg?v=1645647487"
                        }
                    }
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