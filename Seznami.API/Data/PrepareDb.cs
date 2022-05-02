using Seznami.API.Models;

namespace Seznami.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app)
    {
        using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
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
            database.SaveChanges();
        }
        else
        {
            Console.WriteLine("[PrepareDb] Data is present in the database");
        }
    }
}