using Komentiranje.API.Models;

namespace Komentiranje.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
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
                    Komentator = new Komentator {UporabniskoIme = "Janez123"}
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Odličen film",
                    Komentator = new Komentator {UporabniskoIme = "Janez123"}
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Vreden ogleda",
                    Komentator = new Komentator {UporabniskoIme = "Bojan123"}
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Super film",
                    Komentator = new Komentator {UporabniskoIme = "Bojan123"}
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Film je bil predolg",
                    Komentator = new Komentator {UporabniskoIme = "Bojan123"}
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Film je bil dolgočasen",
                    Komentator = new Komentator {UporabniskoIme = "Marjan123"}
                },
                new Komentar
                {
                    DatumZapisa = DateTime.Now,
                    Vsebina = "Film je bil izjemen",
                    Komentator = new Komentator {UporabniskoIme = "Marjan123"}
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