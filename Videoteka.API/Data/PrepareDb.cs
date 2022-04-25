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
                    Opis = "Po letih tavanja po ulicah Gothama in z le nekaj zanesljivimi zavezniki, osamljen maščevalec Batman postane edino utelešenje pravice med svojimi someščani. Ko elito Gothama napade sadističen morilec, vrsta skrivnostnih namigov popelje »viteza teme« globoko v podzemlje, kjer naleti na Selino Kyle aka. Catwoman, Pingvina, Carminea Falconea in seveda Ugankarja. Ko se dokazi začnejo kopičiti in vodijo vedno bliže in bliže domu ter razkrivajo veličino storilčevega zloveščega plana, mora Batman skovati nova zavezništva, razkriti krivca in vrniti pravico mestu Gotham, kateri je bil preveč dolgo zlorabljen s strani pokvarjene oblasti.",
                    Dolzina = 178,
                    ImdbOcena = 8,
                    PGOcena = "PG-13",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/the-batman_tgstxmov_480x.progressive.jpg?v=1641930817",
                    LetoIzdaje = 2022,
                    Napovednik = "mqqft2x_Aa4",
                    SeznamZanrov = new List<Zanr>
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
                        }
                    }
                },
                new Film
                {
                    Naslov = "Tenet",
                    Opis = "Oborožen z zgolj eno besedo – TENET – ter z borbo za preživetje celega sveta, se glavni junak zgodbe prebija skozi mračen svet mednarodnega vohunjenja na misiji, ki se dogaja v nečem izven realnega časa in prostora. To ni potovanje skozi čas.To je inverzija.",
                    Dolzina = 150,
                    ImdbOcena = 7,
                    PGOcena = "PG-13",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/tenet.regstyleb.ar_480x.progressive.jpg?v=1598649994",
                    LetoIzdaje = 2020,
                    Napovednik = "AZGcmvrTX9M",
                    SeznamZanrov = new List<Zanr>
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
                        }
                    }
                },
                new Film
                {
                    Naslov = "Uncharted",
                    Opis = "Po še vedno sveži mega uspešnici Spider-Man: Ni poti domov se Tom Holland vrača na velika platna v vznemirljivi pustolovščini Uncharted kot Nathan Drake – Nate. To je zgodba o lovcu na zaklade in glavnem junaku serije videoiger Uncharted, ki ima po vsem svetu več kot 40 milijonov prodanih izvodov. Film pripoveduje zgodbo o Nathanu Drakeu in njegovi prvi pustolovščini s tekmecem, ki postane njegov partner, Victorjem \"Sullyjem\" Sullivanom. Uncharted predstavlja občinstvu premetenega Nathana Draka (Tom Holland) in njegov prvi lov na zaklad z nabritim kolegom Victorjem Sullivanom – Sullyjem (Mark Wahlberg). Epski akcijsko-pustolovski film, ki ga je navdihnila slavna serija videoiger, sledi Natu in Saullyju po vsem svetu na nevarnem lovu za »največjim doslej še neodkritim zakladom«, obenem pa tudi po različnih sledeh, ki utegnejo pripeljati Nata do davno izgubljene brata. Ta pustolovščina je milijone igralcev po vsem svetu osvojila s svojo zgodbo, inovativnostjo in kinematografskim slogom. Prihajajoči istoimenski film nas bo seznanil z dogodki pred igro, torej z zgodbo o tem, kako je Nate spoznal Victorja Sullivana – Sullyja. S posebnim humorjem in situacijami se bosta nova prijatelja in sodelavca podala v nevarno iskanje izgubljenega zaklada Ferdinanda Magellana, zaklada, ki je izginil pred 500 leti. V tej pustolovščini ju čakajo skrivnostni",
                    Dolzina = 116,
                    ImdbOcena = 6,
                    PGOcena = "PG-13",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/uncharted_s270z86d_480x.progressive.jpg?v=1644515265",
                    LetoIzdaje = 2022,
                    Napovednik = "eHp3MbsCbMg",
                    SeznamZanrov = new List<Zanr>
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
                        }
                    }
                },
                new Film
                {
                    Naslov = "Spider-Man: NWH",
                    Opis = "Ker je Spider-Manova identiteta razkrita, Peter prosi za pomoč doktorja Strangea. Ko gre urok narobe, se začnejo pojavljati nevarni sovražniki iz drugih svetov in Peter mora odkriti, kaj resnično pomeni biti Spider-Man.",
                    Dolzina = 150,
                    ImdbOcena = 8,
                    PGOcena = "PG-13",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/spider-man-no-way-home_l1mupilp_480x.progressive.jpg?v=1640203988",
                    LetoIzdaje = 2021,
                    Napovednik = "JfVOs4VSpmA",
                    SeznamZanrov = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Action"
                        },
                        new()
                        {
                            Naziv = "Adventure"
                        },
                        new()
                        {
                            Naziv = "Fantasy"
                        }
                    },
                    Reziser = new Reziser
                    {
                        Ime = "Jon",
                        Priimek = "Watts"
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
                            Ime = "Zendaya",
                            Priimek = "Coleman"
                        },
                        new()
                        {
                            Ime = "Benedict",
                            Priimek = "Cumberbatch"
                        }
                    }
                },
                new Film
                {
                    Naslov = "Dune",
                    Opis = "Plemiška družina se zaplete v vojno za nadzor nad najdragocenejšim premoženjem galaksije, njenega dediča pa vznemirjajo vizije temačne prihodnosti.",
                    Dolzina = 155,
                    ImdbOcena = 8,
                    PGOcena = "PG-13",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/dune_axfdsg2v_480x.progressive.jpg?v=1635262101",
                    LetoIzdaje = 2021,
                    Napovednik = "8g18jFHCLXk",
                    SeznamZanrov = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Action"
                        },
                        new()
                        {
                            Naziv = "Adventure"
                        },
                        new()
                        {
                            Naziv = "Drama"
                        }
                    },
                    Reziser = new Reziser
                    {
                        Ime = "Denis",
                        Priimek = "Villeneuve"
                    },
                    SeznamIgralcev = new List<IgralecFilma>
                    {
                        new()
                        {
                            Ime = "Timothée",
                            Priimek = "Chalamet"
                        },
                        new()
                        {
                            Ime = "Rebecca",
                            Priimek = "Ferguson"
                        },
                        new()
                        {
                            Ime = "Zendaya",
                            Priimek = "Coleman"
                        }
                    }
                },
                new Film
                {
                    Naslov = "Don't Look Up",
                    Opis = "Dva astronoma nižjega ranga se morata odpraviti na velikansko medijsko turnejo, da bi človeštvo opozorila na bližajoči se komet, ki bo uničil planet Zemljo.",
                    Dolzina = 138,
                    ImdbOcena = 7,
                    PGOcena = "R",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/dont-look-up_xqrmuoe4_480x.progressive.jpg?v=1645647487",
                    LetoIzdaje = 2021,
                    Napovednik = "RbIxYm3mKzI",
                    SeznamZanrov = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Comedy"
                        },
                        new()
                        {
                            Naziv = "Drama"
                        },
                        new()
                        {
                            Naziv = "Sci-Fi"
                        }
                    },
                    Reziser = new Reziser
                    {
                        Ime = "Adam",
                        Priimek = "McKay"
                    },
                    SeznamIgralcev = new List<IgralecFilma>
                    {
                        new()
                        {
                            Ime = "Leonardo",
                            Priimek = "DiCaprio"
                        },
                        new()
                        {
                            Ime = "Jennifer",
                            Priimek = "Lawrence"
                        },
                        new()
                        {
                            Ime = "Meryl",
                            Priimek = "Streep"
                        }
                    }
                },
                new Film
                {
                    Naslov = "Joker",
                    Opis = "Komik, ki je v duševnih težavah, se poda na spiralo, ki ga pripelje do tega, da ustvari kultnega zlobneža.",
                    Dolzina = 122,
                    ImdbOcena = 8,
                    PGOcena = "R",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/JOKER.PW.REP_480x.progressive.jpg?v=1574965207",
                    LetoIzdaje = 2019,
                    Napovednik = "zAGVQLHvwOY",
                    SeznamZanrov = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Crime"
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
                        Ime = "Todd",
                        Priimek = "Phillips"
                    },
                    SeznamIgralcev = new List<IgralecFilma>
                    {
                        new()
                        {
                            Ime = "Joaquin",
                            Priimek = "Phoenix"
                        },
                        new()
                        {
                            Ime = "Robert",
                            Priimek = "De Niro"
                        },
                        new()
                        {
                            Ime = "Zazie",
                            Priimek = "Beetz"
                        }
                    }
                },
                new Film
                {
                    Naslov = "Interstellar",
                    Opis = "Ekipa raziskovalcev potuje skozi črvino v vesolju, da bi zagotovila preživetje človeštva.",
                    Dolzina = 169,
                    ImdbOcena = 9,
                    PGOcena = "PG-13",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/interstellar5_480x.progressive.jpg?v=1585846879",
                    LetoIzdaje = 2014,
                    Napovednik = "zSWdZVtXT7E",
                    SeznamZanrov = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Adventure"
                        },
                        new()
                        {
                            Naziv = "Drama"
                        },
                        new()
                        {
                            Naziv = "Sci-Fi"
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
                            Ime = "Matthew",
                            Priimek = "McConaughey"
                        },
                        new()
                        {
                            Ime = "Anne",
                            Priimek = "Hathaway"
                        },
                        new()
                        {
                            Ime = "Jessica",
                            Priimek = "Chastain"
                        }
                    }
                },
                new Film
                {
                    Naslov = "Free Guy",
                    Opis = "Bančni uslužbenec odkrije, da je pravzaprav nepoklicna oseba v brutalni videoigri z odprtim svetom.",
                    Dolzina = 115,
                    ImdbOcena = 7,
                    PGOcena = "PG-13",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/free-guy_1xfacsl5_480x.progressive.jpg?v=1624549634",
                    LetoIzdaje = 2021,
                    Napovednik = "X2m-08cOAbc",
                    SeznamZanrov = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Action"
                        },
                        new()
                        {
                            Naziv = "Adventure"
                        },
                        new()
                        {
                            Naziv = "Comedy"
                        }
                    },
                    Reziser = new Reziser
                    {
                        Ime = "Shawn",
                        Priimek = "Levy"
                    },
                    SeznamIgralcev = new List<IgralecFilma>
                    {
                        new()
                        {
                            Ime = "Ryan",
                            Priimek = "Reynolds"
                        },
                        new()
                        {
                            Ime = "Jodie",
                            Priimek = "Comer"
                        },
                        new()
                        {
                            Ime = "Taika",
                            Priimek = "Waititi"
                        }
                    }
                },
                new Film
                {
                    Naslov = "No Time To Die",
                    Opis = "James Bond je zapustil aktivno službo. Njegov mir je kratkotrajen, ko se pojavi Felix Leiter, stari prijatelj iz Cie, ki ga prosi za pomoč, in Bonda pripelje na sled skrivnostnemu zlikovcu, oboroženemu z nevarno novo tehnologijo.",
                    Dolzina = 163,
                    ImdbOcena = 7,
                    PGOcena = "PG-13",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/notimetodie.pyra.rep_480x.progressive.jpg?v=1592588036",
                    LetoIzdaje = 2021,
                    Napovednik = "BIhNsAtPbPI",
                    SeznamZanrov = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Action"
                        },
                        new()
                        {
                            Naziv = "Adventure"
                        },
                        new()
                        {
                            Naziv = "Thriller"
                        }
                    },
                    Reziser = new Reziser
                    {
                        Ime = "Cary",
                        Priimek = "Joji Fukunaga"
                    },
                    SeznamIgralcev = new List<IgralecFilma>
                    {
                        new()
                        {
                            Ime = "Daniel",
                            Priimek = "Craig"
                        },
                        new()
                        {
                            Ime = "Ana",
                            Priimek = "de Armas"
                        },
                        new()
                        {
                            Ime = "Rami",
                            Priimek = "Malek"
                        }
                    }
                },
                new Film
                {
                    Naslov = "Forrest Gump",
                    Opis = "Predsedovanje Kennedyja in Johnsona, vietnamska vojna, škandal Watergate in drugi zgodovinski dogodki se odvijajo s perspektive moškega iz Alabame z IQ 75, ki si želi le, da bi se ponovno srečal s svojo ljubeznijo iz otroštva.",
                    Dolzina = 144,
                    ImdbOcena = 9,
                    PGOcena = "PG-13",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/77e810938fdaf6a8a6879aabef828d78_7b4c41f9-0c33-4b0e-acb3-93bad47e4347_480x.progressive.jpg?v=1573587341",
                    LetoIzdaje = 1994,
                    Napovednik = "bLvqoHBptjg",
                    SeznamZanrov = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Drama"
                        },
                        new()
                        {
                            Naziv = "Romance"
                        }
                    },
                    Reziser = new Reziser
                    {
                        Ime = "Robert",
                        Priimek = "Zemeckis"
                    },
                    SeznamIgralcev = new List<IgralecFilma>
                    {
                        new()
                        {
                            Ime = "Tom",
                            Priimek = "Hanks"
                        },
                        new()
                        {
                            Ime = "Robin",
                            Priimek = "Wright"
                        },
                        new()
                        {
                            Ime = "Gary",
                            Priimek = "Sinise"
                        }
                    }
                },
                new Film
                {
                    Naslov = "Inception",
                    Opis = "Vrag, ki krade poslovne skrivnosti s pomočjo tehnologije za izmenjavo sanj, dobi obratno nalogo - vcepiti idejo v um izvršnega direktorja, vendar lahko njegova tragična preteklost projekt in njegovo ekipo obsodi na propad.",
                    Dolzina = 148,
                    ImdbOcena = 9,
                    PGOcena = "PG-13",
                    Poster = "https://cdn.shopify.com/s/files/1/0057/3728/3618/products/7dfddd911b8040729896c5be83f8e139_6e2f4149-8cb4-414c-a33b-9e0065c55af3_480x.progressive.jpg?v=1573585216",
                    LetoIzdaje = 2010,
                    Napovednik = "YoHD9XEInc0",
                    SeznamZanrov = new List<Zanr>
                    {
                        new()
                        {
                            Naziv = "Action"
                        },
                        new()
                        {
                            Naziv = "Adventure"
                        },
                        new()
                        {
                            Naziv = "Sci-Fi"
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
                            Ime = "Leonardo",
                            Priimek = "DiCaprio"
                        },
                        new()
                        {
                            Ime = "Joseph",
                            Priimek = "Gordon-Levitt"
                        },
                        new()
                        {
                            Ime = "Elliot",
                            Priimek = "Page"
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