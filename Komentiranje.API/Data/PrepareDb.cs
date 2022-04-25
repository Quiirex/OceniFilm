using Komentiranje.API.Models;

namespace Komentiranje.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app)
    {
        using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<KomentiranjeDbContext>());
    }

    private static void SeedData(KomentiranjeDbContext database)
    {
        if (!database.Komentarji.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding data...", DateTime.Now);

            database.Komentarji.AddRange(
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Ta film mi je bil zelo všeč",
                    KomentiranFilm = new KomentiranFilm { Naslov = "The Batman" },
                    Komentator = new Komentator { Guid = "Janez123" }
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Odličen film",
                    KomentiranFilm = new KomentiranFilm { Naslov = "The Batman" },
                    Komentator = new Komentator { Guid = "Janez123" }
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Vreden ogleda",
                    KomentiranFilm = new KomentiranFilm { Naslov = "The Batman" },
                    Komentator = new Komentator { Guid = "Bojan123" }
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Super film",
                    KomentiranFilm = new KomentiranFilm { Naslov = "The Batman" },
                    Komentator = new Komentator { Guid = "Bojan123" }
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Film je bil predolg",
                    KomentiranFilm = new KomentiranFilm { Naslov = "The Batman" },
                    Komentator = new Komentator { Guid = "Bojan123" }
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Film je bil dolgočasen",
                    KomentiranFilm = new KomentiranFilm { Naslov = "The Batman" },
                    Komentator = new Komentator { Guid = "Marjan123" }
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Film je bil izjemen",
                    KomentiranFilm = new KomentiranFilm { Naslov = "The Batman" },
                    Komentator = new Komentator { Guid = "Marjan123" }
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