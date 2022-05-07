using Identiteta.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Identiteta.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app, bool SQLServ)
    {
        using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<IdentitetaDbContext>(), SQLServ);
    }

    private static void SeedData(IdentitetaDbContext dbContext, bool SQLServ)
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

        if (!dbContext.Uporabniki.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding identity data...", DateTime.Now);

            dbContext.Uporabniki.AddRange(
                new Uporabnik
                {
                    Id = "4564-2345-7445-2345-1235-1236",
                    Ime = "Janez",
                    Priimek = "Novak",
                    PrikaznoIme = "janezek12",
                    Email = "janez123@fakemail.com",
                    Geslo = "7BWpQ8GccFHz/seVU5QBsq9RZX/Wh2NQj81uJTEoiuE=", //janez123!
                    Sol = "hgiaDRhm6EmR1B+iME2uFg==",
                    DatumRojstva = new DateTime(1996, 10, 24)
                },
                new Uporabnik
                {
                    Id = "1235-9345-3353-8766-1235-8454",
                    Ime = "Marjan",
                    Priimek = "Zilavec",
                    PrikaznoIme = "marjanZilla",
                    Email = "marjan123@fakemail.com",
                    Geslo = "n13ALhiWqhUWcZ1NBNIkt2HgV0DPAEVk32FX271gcZo=", //marjan123!
                    Sol = "+5lg8gQY18H9wbb0FodhIw==",
                    DatumRojstva = new DateTime(1990, 12, 5)
                },
                new Uporabnik
                {
                    Id = "7833-1305-8793-2354-7893-2768",
                    Ime = "Bojan",
                    Priimek = "Horvat",
                    PrikaznoIme = "bojko12",
                    Email = "bojan123@fakemail.com",
                    Geslo = "OwWEhO5nrXfKnqRNG/c8kE/ZKrpg//R8GZev0DYyHn0=", //bojan123!
                    Sol = "fnM3IIWN1tfFS/f+L4dbXw==",
                    DatumRojstva = new DateTime(1967, 4, 19)
                }
            );
            dbContext.SaveChanges();
        }
        else
        {
            Console.WriteLine("[PrepareDb] Identity data is present in the database");
        }
    }
}