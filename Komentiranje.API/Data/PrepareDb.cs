using Komentiranje.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Komentiranje.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app, bool SQLServ)
    {
        using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<KomentiranjeDbContext>(), SQLServ);
    }

    private static void SeedData(KomentiranjeDbContext dbContext, bool SQLServ)
    {
        if (SQLServ)
        {
            try
            {
                dbContext.Database.Migrate();
                Console.WriteLine($"[PrepareDb] Migration successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PrepareDb] Migration unsuccessful: {ex.Message}");
            }
        }

        if (!dbContext.Komentarji.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding data...", DateTime.Now);

            dbContext.Komentarji.AddRange(
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Ta film mi je bil zelo všeč",
                    KomentiranFilm = new KomentiranFilm { Naslov = "The Batman" },
                    Komentator = new Komentator { PrikaznoIme = "janezek12" }
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Odličen film",
                    KomentiranFilm = new KomentiranFilm { Naslov = "The Batman" },
                    Komentator = new Komentator { PrikaznoIme = "bojko12" }
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Film je bil dolgočasen",
                    KomentiranFilm = new KomentiranFilm { Naslov = "Tenet" },
                    Komentator = new Komentator { PrikaznoIme = "marjanZilla" }
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