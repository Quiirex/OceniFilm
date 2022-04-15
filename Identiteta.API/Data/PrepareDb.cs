using Identiteta.API.Models;

namespace Identiteta.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<IdentitetaDbContext>());
    }

    private static void SeedData(IdentitetaDbContext database)
    {
        if (!database.Uporabniki.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding data...", DateTime.Now);

            database.Uporabniki.AddRange(
                new Uporabnik
                {
                    Id = "4564-2345-7445-2345-1235-1235",
                    Ime = "Janez",
                    Priimek = "Novak",
                    PrikaznoIme = "janezekN",
                    Email = "janez123@fakemail.com",
                    Geslo = "F/SVofkx6+YuqhAjJkC/c6f9hBJO+RVrgGi9gf1060s=", //janez123!
                    Sol = "U8L2S/YMt3UEwjORJ7QxzA==",
                    DatumRojstva = new DateTime(1990, 10, 25)
                },
                new Uporabnik
                {
                    Id = "1235-9345-3353-8766-1235-8453",
                    Ime = "Marjan",
                    Priimek = "Zilavec",
                    PrikaznoIme = "marjanZilla",
                    Email = "marjan123@fakemail.com",
                    Geslo = "/YZ27RfExOeLcDHNGEjPgot2VZA5xJUR1EdeUNd5RWU=", //marjan123!
                    Sol = "RonOFpZdgK2e8wTj62ywiA==",
                    DatumRojstva = new DateTime(1994, 7, 2)
                },
                new Uporabnik
                {
                    Id = "7833-1305-8793-2354-7893-2767",
                    Ime = "Bojan",
                    Priimek = "Horvat",
                    PrikaznoIme = "bojko12",
                    Email = "bojan123@fakemail.com",
                    Geslo = "jQUqAsEebdgwa+Z7fIROR887Er4+gbw1MpVddj4ZlHc=", //bojan123!
                    Sol = "NbcgY1ZW6+TShCHi6Cws7w==",
                    DatumRojstva = new DateTime(1990, 10, 25)
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