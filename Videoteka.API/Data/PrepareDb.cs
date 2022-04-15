using Videoteka.API.Models;

namespace Videoteka.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app)
    {
        using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<VideotekaDbContext>());
    }


    private static void SeedData(VideotekaDbContext database)
    {
        if (!database.Filmi.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding data...", DateTime.Now);

            database.Filmi.AddRange(
                new Film
                {
                    Naslov = "The Batman",
                    Opis =
                        "Po letih tavanja po ulicah Gothama in z le nekaj zanesljivimi zavezniki, osamljen maščevalec Batman postane edino utelešenje pravice med svojimi someščani. Ko elito Gothama napade sadističen morilec, vrsta skrivnostnih namigov popelje »viteza teme« globoko v podzemlje, kjer naleti na Selino Kyle aka. Catwoman, Pingvina, Carminea Falconea in seveda Ugankarja. Ko se dokazi začnejo kopičiti in vodijo vedno bliže in bliže domu ter razkrivajo veličino storilčevega zloveščega plana, mora Batman skovati nova zavezništva, razkriti krivca in vrniti pravico mestu Gotham, kateri je bil preveč dolgo zlorabljen s strani pokvarjene oblasti.",
                    Dolzina = 178,
                    ImdbOcena = 8,
                    Poster =
                        "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/the-batman_tgstxmov_480x.progressive.jpg?v=1641930817",
                    LetoIzdaje = 2022,
                    Napovednik = "mqqft2x_Aa4",
                    SeznamZanr = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Horror"
                        },
                        new()
                        {
                            Naziv = "Dark"
                        },
                        new()
                        {
                            Naziv = "Thriller"
                        },
                        new()
                        {
                            Naziv = "Scary"
                        }
                    },
                    Reziser = new Reziser
                    {
                        Ime = "Matt",
                        Priimek = "Reeves"
                    },
                    SeznamIgralcev = new List<IgralecFilma>
                    {
                        new()
                        {
                            Ime = "Robert",
                            Priimek = "Pattinson"
                        },
                        new()
                        {
                            Ime = "Zoë",
                            Priimek = "Kravitz"
                        },
                        new()
                        {
                            Ime = "Paul",
                            Priimek = "Dano"
                        },
                        new()
                        {
                            Ime = "Jeffrey",
                            Priimek = "Wright"
                        },
                        new()
                        {
                            Ime = "Peter",
                            Priimek = "Sarsgaard"
                        }
                    }
                },
                new Film
                {
                    Naslov = "Tenet",
                    Opis =
                        "Oborožen z zgolj eno besedo – TENET – ter z borbo za preživetje celega sveta, se glavni junak zgodbe prebija skozi mračen svet mednarodnega vohunjenja na misiji, ki se dogaja v nečem izven realnega časa in prostora. To ni potovanje skozi čas.To je inverzija.",
                    Dolzina = 150,
                    ImdbOcena = 7,
                    Poster =
                        "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/tenet.regstyleb.ar_480x.progressive.jpg?v=1598649994",
                    LetoIzdaje = 2020,
                    Napovednik = "AZGcmvrTX9M",
                    SeznamZanr = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Action"
                        },
                        new()
                        {
                            Naziv = "Drama"
                        },
                        new()
                        {
                            Naziv = "Thriller"
                        }
                    },
                    Reziser = new Reziser
                    {
                        Ime = "Christopher",
                        Priimek = "Nolan"
                    },
                    SeznamIgralcev = new List<IgralecFilma>
                    {
                        new()
                        {
                            Ime = "Robert",
                            Priimek = "Pattinson"
                        },
                        new()
                        {
                            Ime = "Aaron",
                            Priimek = "Taylor-Johnson"
                        },
                        new()
                        {
                            Ime = "Kenneth",
                            Priimek = "Branagh"
                        },
                        new()
                        {
                            Ime = "Elizabeth",
                            Priimek = "Debicki"
                        },
                        new()
                        {
                            Ime = "John David",
                            Priimek = "Washington"
                        }
                    }
                },
                new Film
                {
                    Naslov = "Uncharted",
                    Opis =
                        "Po še vedno sveži mega uspešnici Spider-Man: Ni poti domov se Tom Holland vrača na velika platna v vznemirljivi pustolovščini Uncharted kot Nathan Drake – Nate. To je zgodba o lovcu na zaklade in glavnem junaku serije videoiger Uncharted, ki ima po vsem svetu več kot 40 milijonov prodanih izvodov. Film pripoveduje zgodbo o Nathanu Drakeu in njegovi prvi pustolovščini s tekmecem, ki postane njegov partner, Victorjem \"Sullyjem\" Sullivanom. Uncharted predstavlja občinstvu premetenega Nathana Draka (Tom Holland) in njegov prvi lov na zaklad z nabritim kolegom Victorjem Sullivanom – Sullyjem (Mark Wahlberg). Epski akcijsko-pustolovski film, ki ga je navdihnila slavna serija videoiger, sledi Natu in Saullyju po vsem svetu na nevarnem lovu za »največjim doslej še neodkritim zakladom«, obenem pa tudi po različnih sledeh, ki utegnejo pripeljati Nata do davno izgubljene brata. Ta pustolovščina je milijone igralcev po vsem svetu osvojila s svojo zgodbo, inovativnostjo in kinematografskim slogom. Prihajajoči istoimenski film nas bo seznanil z dogodki pred igro, torej z zgodbo o tem, kako je Nate spoznal Victorja Sullivana – Sullyja. S posebnim humorjem in situacijami se bosta nova prijatelja in sodelavca podala v nevarno iskanje izgubljenega zaklada Ferdinanda Magellana, zaklada, ki je izginil pred 500 leti. V tej pustolovščini ju čakajo skrivnostni",
                    Dolzina = 116,
                    ImdbOcena = 6,
                    Poster =
                        "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/uncharted_s270z86d_480x.progressive.jpg?v=1644515265",
                    LetoIzdaje = 2022,
                    Napovednik = "eHp3MbsCbMg",
                    SeznamZanr = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Action"
                        },
                        new()
                        {
                            Naziv = "Adventure"
                        }
                    },
                    Reziser = new Reziser
                    {
                        Ime = "Ruben",
                        Priimek = "Fleischer"
                    },
                    SeznamIgralcev = new List<IgralecFilma>
                    {
                        new()
                        {
                            Ime = "Tom",
                            Priimek = "Holland"
                        },
                        new()
                        {
                            Ime = "Mark",
                            Priimek = "Wahlberg"
                        },
                        new()
                        {
                            Ime = "Tati",
                            Priimek = "Gabrielle"
                        },
                        new()
                        {
                            Ime = "Antonio",
                            Priimek = "Banderas"
                        },
                        new()
                        {
                            Ime = "Sophia",
                            Priimek = "Ali"
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