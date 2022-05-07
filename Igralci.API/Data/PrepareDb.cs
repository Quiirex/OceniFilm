using Igralci.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Igralci.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app, bool SQLServ)
    {
        using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<IgralciDbContext>(), SQLServ);
    }

    private static void SeedData(IgralciDbContext dbContext, bool SQLServ)
    {
        if (SQLServ)
        {
            try
            {
                dbContext.Database.Migrate();
                Console.WriteLine("[PrepareDb] Migration successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PrepareDb] Migration unsuccessful: {ex.Message}");
            }
        }

        if (!dbContext.Igralci.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding data...", DateTime.Now);

            dbContext.Igralci.AddRange(
                new Igralec
                {
                    Ime = "Robert",
                    Priimek = "Pattinson",
                    Biografija = "Pattinson, ki je bil rojen in vzgojen v Londonu, je s kariero pričel kot amaterski igralec v gledališču. Zatem je deloval tudi kot fotomodel, a s tem poslom je po komaj štirih letih prenehal. Svoj preboj je doživel z vlogo Cedrica Diggorya v filmu Harry Potter in ognjeni kelih, posnetem po istoimenskem romanu J.K. Rowling. Kasneje je dobil vlogo Edwarda Cullena v filmski seriji Somrak, posneti po romanih iz istoimenske knjižne serije Stephenie Meyer, s katero je postal prepoznaven po svetu in za katero je prejel mnogo nagrad.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Robert_Pattinson_Premiere_of_The_Lost_City_of_Z_at_Zoo_Palast_Berlinale_2017_02.jpg/800px-Robert_Pattinson_Premiere_of_The_Lost_City_of_Z_at_Zoo_Palast_Berlinale_2017_02.jpg",
                },
                new Igralec
                {
                    Ime = "Timothée",
                    Priimek = "Chalamet",
                    Biografija = "Chalamet se je rodil in odraščal v New Yorku, kariero pa je začel na odru in v televizijskih produkcijah ter leta 2012 nastopil v dramski seriji Domovina. Dve leti pozneje je debitiral v celovečercu v komični drami Men, Women & Children in nastopil v znanstvenofantastičnem filmu Christopherja Nolana Interstellar. Mednarodno pozornost je Chalamet pritegnil z glavno vlogo zaljubljenega najstnika v filmu Luce Guadagnina o odraščanju Pokliči me po svojem imenu (2017), ki mu je prinesla nominacijo za oskarja za najboljšega igralca. Sledili sta stranski vlogi v filmih Grete Gerwig Lady Bird (2017) in Little Women (2019), nato pa je prevzel glavni vlogi Nica Sheffa v drami Beautiful Boy (2018) in Paula Atreidesa v znanstvenofantastičnem filmu Denisa Villeneuva Dune (2021).",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Timoth%C3%A9e_Chalamet_2017_Berlinale.jpg/800px-Timoth%C3%A9e_Chalamet_2017_Berlinale.jpg",
                },
                new Igralec
                {
                    Ime = "Tom",
                    Priimek = "Holland",
                    Biografija = "Hollandova kariera se je začela pri devetih letih, ko se je vpisal v plesni tečaj, kjer ga je opazil koreograf in mu uredil avdicijo za vlogo v muzikalu Billy Elliot v londonskem gledališču Victoria Palace. Po dveh letih treninga je leta 2008 dobil stransko vlogo in še istega leta glavno vlogo, ki jo je igral do leta 2010. Holland je v filmu debitiral v drami o katastrofi Nemogoče (2012) v vlogi najstniškega turista, ujetega v cunamiju, za katero je prejel nagrado London Film Critics Circle za mladega britanskega igralca leta. Po tem se je Holland odločil, da se bo igralstvu posvetil za polni delovni čas, in tako je nastopil v filmu Kako živim zdaj (2013) ter igral zgodovinske osebnosti v filmu V osrčju morja (2015) in miniseriji Wolf Hall (2015).",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3c/Tom_Holland_by_Gage_Skidmore.jpg/800px-Tom_Holland_by_Gage_Skidmore.jpg",
                },
                new Igralec
                {
                    Ime = "Leonardo",
                    Priimek = "DiCaprio",
                    Biografija = "DiCaprio se je rodil v Los Angelesu in svojo kariero začel konec osemdesetih let prejšnjega stoletja z nastopanjem v televizijskih oglasih. V začetku devetdesetih let je imel ponavljajoče se vloge v različnih televizijskih oddajah, kot je na primer sitcom Parenthood, in svojo prvo večjo filmsko vlogo kot pisatelj Tobias Wolff v filmu This Boy's Life (1993). Pri 19 letih je prejel priznanje kritikov ter prvi nominaciji za oskarja in zlati globus za vlogo dečka z motnjo v razvoju v filmu What's Eating Gilbert Grape (1993).",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/4/46/Leonardo_Dicaprio_Cannes_2019.jpg",
                },
                new Igralec
                {
                    Ime = "Ana",
                    Priimek = "de Armas",
                    Biografija = "Po selitvi v Los Angeles je de Armas odigrala angleško govoreče vloge v erotičnem trilerju Knock Knock (2015) in komično-kriminalnem filmu War Dogs (2016) ter stransko vlogo v športni biografiji Hands of Stone (2016). Zaslovela je z vlogo holografske projekcije umetne inteligence v znanstvenofantastičnem filmu Blade Runner 2049 (2017). Za vlogo medicinske sestre Marte Cabrere v skrivnostnem filmu Knives Out (2019) je bila de Armasova nominirana za zlati globus za najboljšo igralko v komediji ali muzikalu in prejela nagrado Saturn za najboljšo stransko igralko. Igrala je Bondovo dekle Palomo v filmu o Jamesu Bondu Ni časa za smrt (2021), v Netflixovi biografski drami Blonde (2022) pa naj bi upodobila Marilyn Monroe.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/e/e8/Ana_De_Armas_%28cropped%29.png",
                },
                new Igralec
                {
                    Ime = "Zendaya",
                    Priimek = "Coleman",
                    Biografija = "Svojo kariero je začela kot otroški model, ko je delala za Macy's, Mervyns in Old Navy. Bila je spremljevalna plesalka, nato pa je zaslovela z vlogo Rocky Blue v komediji Shake It Up (2010) na Disney Channelu, v kateri igrajo tudi Bella Thorne, Kenton Duty in Roshon Fegan.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/28/Zendaya_-_2019_by_Glenn_Francis.jpg/800px-Zendaya_-_2019_by_Glenn_Francis.jpg"
                },
                new Igralec
                {
                    Ime = "Natalie",
                    Priimek = "Portman",
                    Biografija = "Je edini otrok Avnerja Hershlaga, v Izraelu rojenega zdravnika, in Shelley Stevens, v ZDA rojene umetnice (iz Cincinnatija v Ohiu), ki je tudi Natalijina agentka. Njena starša sta aškenazijskega judovskega porekla. Natalijina družina se je iz Izraela preselila v Washington, D.C., ko je bila Natalie še zelo majhna. Po nekaj selitvah se je družina končno ustalila v New Yorku, kjer živi še danes. Maturirala je z odliko, njeni akademski dosežki pa so ji omogočili študij na univerzi Harvard. Pri 11 letih jo je v piceriji odkril agent. Nagovarjal jo je k manekenski karieri, vendar se je odločila, da se bo raje posvetila igralski karieri. Nastopila je v številnih nastopih v živo, v filmu Léon pa je debitirala v močni filmski vlogi: (1994) (tudi \"Léon\"). Po tej vlogi je Natalie dobila vloge v filmih, kot so Vročina (1995), Lepa dekleta (1996) in Mars napada! (1996).",
                    Fotografija = "https://media.vanityfair.com/photos/5e4563b4609b5f0008cf47bc/master/pass/GettyImages-1205162493.jpg",
                },
                new Igralec
                {
                    Ime = "Jennifer",
                    Priimek = "Lawrence",
                    Biografija = "V otroštvu je Lawrence nastopal v cerkvenih igrah in šolskih muzikalih. Pri 14 letih jo je med počitnicami v New Yorku z družino opazil iskalec talentov. Preselila se je v Los Angeles in začela igralsko kariero z gostujočimi vlogami na televiziji. Njena prva večja vloga je bila glavna igralka v komediji The Bill Engvall Show (2007-2009). Na filmu je debitirala v stranski vlogi v drami Garden Party (2008), preboj pa je doživela z vlogo revne najstnice v neodvisni skrivnostni drami Winter's Bone (2010). Lawrenceova kariera je napredovala z glavnima vlogama mutantke Mystique v seriji filmov Možje X (2011-2019) in Katniss Everdeen v seriji filmov Igre lakote (2012-2015). S slednjo je postala najdonosnejša akcijska junakinja vseh časov.",
                    Fotografija = "https://www.pinkvilla.com/files/styles/amp_metadata_content_image/public/jennifer_lost_tooth.jpg",
                },
                new Igralec
                {
                    Ime = "Anne",
                    Priimek = "Hathaway",
                    Biografija = "Hathawayeva je končala srednjo šolo Millburn High School v New Jerseyju, kjer je igrala v več predstavah. Kot najstnica je igrala v televizijski seriji Get Real (1999-2000), preboj pa ji je uspel z vlogo glavne junakinje v njenem filmskem prvencu, Disneyjevi komediji The Princess Diaries (2001). Po nastopu v vrsti neuspešnih družinskih filmov je Hathawayeva prešla k vlogam za odrasle z dramama Havoc in Brokeback Mountain iz leta 2005. Komična drama Hudič nosi Prado (The Devil Wears Prada, 2006), v kateri je igrala pomočnico urednice modne revije, je bila do takrat njen največji komercialni uspeh. V drami Rachel se poroči (Rachel Getting Married, 2008) je igrala ozdravljeno odvisnico z duševno boleznijo, za katero je bila nominirana za oskarja za najboljšo igralko.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cd/Anne_Hathaway_at_MIFF_%28cropped%29.jpg/800px-Anne_Hathaway_at_MIFF_%28cropped%29.jpg",
                },
                new Igralec
                {
                    Ime = "Zoë",
                    Priimek = "Kravitz",
                    Biografija = "Zoë Isabella Kravitz (born December 1, 1988) is an American actress, singer, and model. The daughter of actor-musician Lenny Kravitz and actress Lisa Bonet, she made her acting debut in the romantic comedy film No Reservations (2007). Her breakthrough came with portraying Angel Salvadore in the superhero film X-Men: First Class (2011), which earned her nominations for a Teen Choice Award and a Scream Award. She rose to prominence playing Christina in The Divergent Series (2014–2016) and Leta Lestrange in the Fantastic Beasts film series (2016–2022).",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/Zoe_Kravitz_2020_dvna_studio_2.jpg/220px-Zoe_Kravitz_2020_dvna_studio_2.jpg",
                },
                new Igralec
                {
                    Ime = "Paul",
                    Priimek = "Dano",
                    Biografija = "Paul Franklin Dano  born June 19, 1984 is an American actor, director and musician. He began his career on Broadway before making his film debut in The Newcomers (2000). He won the Independent Spirit Award for Best Debut Performance for his role in L.I.E. (2001) and received accolades for his role as Dwayne Hoover in Little Miss Sunshine (2006). For his dual roles as Paul and Eli Sunday in Paul Thomas Anderson's There Will Be Blood (2007), he was nominated for the BAFTA Award for Best Supporting Actor.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Paul_Dano_Cannes_2015.jpg/220px-Paul_Dano_Cannes_2015.jpg",
                },
                new Igralec
                {
                    Ime = "Aaron",
                    Priimek = "Taylor-Johnson",
                    Biografija = "Aaron Perry Taylor-Johnson born 13 June 1990 is an English actor. He is best known for his portrayal of the title character in Kick-Ass (2010) and its 2013 sequel, and the Marvel Cinematic Universe (MCU) character Pietro Maximoff in Avengers: Age of Ultron (2015). Taylor-Johnson began performing at age six and has appeared in such films as Shanghai Knights (2003), The Illusionist (2006), The Thief Lord (2006), and Angus, Thongs and Perfect Snogging (2008).",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/26/Aaron_Taylor-Johnson_%2830666613788%29_%28cropped%29.jpg/220px-Aaron_Taylor-Johnson_%2830666613788%29_%28cropped%29.jpg",
                },
                new Igralec
                {
                    Ime = "Kenneth",
                    Priimek = "Branagh",
                    Biografija = "Sir Kenneth Charles Branagh born 10 December 1960 is a British actor and filmmaker. Branagh trained at the Royal Academy of Dramatic Art in London and has served as its president since 2015. He has won an Academy Award, four BAFTAs (plus two honorary awards), two Emmy Awards, and a Golden Globe Award. He was appointed a Knight Bachelor in the 2012 Birthday Honours and knighted on 9 November 2012. He was made a Freeman of his native city of Belfast in January 2018. In 2020, he was listed at number 20 on The Irish Times list of Ireland's greatest film actors.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c7/KennethBranaghApr2011.jpg/220px-KennethBranaghApr2011.jpg",
                },
                new Igralec
                {
                    Ime = "Mark",
                    Priimek = "Wahlberg",
                    Biografija = "Mark Robert Michael Wahlberg born June 5, 1971, former stage name Marky Mark, is an American actor, producer, businessman and former rapper. He has received multiple accolades, including a BAFTA Award, and nominations for two Academy Awards, three Golden Globe Awards, nine Primetime Emmy Awards, and three Screen Actors Guild Awards.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/26/Mark_Wahlberg_2021.jpg/220px-Mark_Wahlberg_2021.jpg",
                },
                new Igralec
                {
                    Ime = "Tati",
                    Priimek = "Gabrielle",
                    Biografija = "Tatiana Gabrielle Hobson born January 25, 1996 is an American actress. She is known for her roles as Gaia on The CW science fiction television series The 100, Prudence on the Netflix original series Chilling Adventures of Sabrina, Marienne Bellamy on the Netflix series You, and for providing the voice of Willow Park on the Disney animated series The Owl House.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bb/Tati-gabrielle-attends-the-cfda-fashion-awards-in-new-york-6-681x1024.jpg/220px-Tati-gabrielle-attends-the-cfda-fashion-awards-in-new-york-6-681x1024.jpg",
                },
                new Igralec
                {
                    Ime = "Benedict",
                    Priimek = "Cumberbatch",
                    Biografija = "Benedict Timothy Carlton Cumberbatch CBE born 19 July 1976 is an English actor. Known for his roles on the screen and stage, he has received various accolades throughout his career, including a British Academy Television Award, a Primetime Emmy Award, a Critics' Choice Television Award and a Laurence Olivier Award. He won the British Academy Television Award for Best Actor for playing the title role in the five-part drama miniseries Patrick Melrose. Cumberbatch won the Primetime Emmy Award for Outstanding Lead Actor for Sherlock and the Laurence Olivier Award for Best Actor for Frankenstein.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6e/BCumberbatch_Comic-Con_2019.jpg/220px-BCumberbatch_Comic-Con_2019.jpg",
                },
                new Igralec
                {
                    Ime = "Rebecca",
                    Priimek = "Ferguson",
                    Biografija = "Rebecca Louisa Ferguson Sundström born 19 October 1983 is a Swedish actress. She began her acting career with the Swedish soap opera Nya tider (1999–2000) and went on to star in the slasher film Drowning Ghost (2004). She came to international prominence with her portrayal of Elizabeth Woodville in the British television miniseries The White Queen (2013), for which she was nominated for a Golden Globe for Best Actress in a Miniseries or Television Film.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b3/Rebecca_Ferguson_in_2018.jpg/220px-Rebecca_Ferguson_in_2018.jpg",
                },
                new Igralec
                {
                    Ime = "Meryl",
                    Priimek = "Streep",
                    Biografija = "Mary Louise \"Meryl\" Streep (born June 22, 1949) is an American actress. Often described as \"the best actress of her generation\", Streep is particularly known for her versatility and accent adaptability. She has received numerous accolades throughout her career spanning over four decades, including a record 21 Academy Award nominations, winning three,[3] and a record 32 Golden Globe Award nominations, winning eight. She has also received two British Academy Film Awards, two Screen Actors Guild Awards, and three Primetime Emmy Awards, in addition to nominations for a Tony Award and six Grammy Awards.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Meryl_Streep_December_2018.jpg/220px-Meryl_Streep_December_2018.jpg",
                },
                new Igralec
                {
                    Ime = "Joaquin",
                    Priimek = "Phoenix",
                    Biografija = "Joaquin Rafael Phoenix born October 28, 1974 is an American actor. Known for playing dark and unconventional characters in independent films, he has received various accolades, including an Academy Award, a British Academy Film Award, a Grammy Award, and two Golden Globe Awards. In 2020, he was ranked 12th on the list of the 25 Greatest Actors of the 21st Century by The New York Times.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/aa/Joaquin_Phoenix-1325.jpg_%28cropped%29.jpg/220px-Joaquin_Phoenix-1325.jpg_%28cropped%29.jpg",
                },
                new Igralec
                {
                    Ime = "Robert",
                    Priimek = "De Niro",
                    Biografija = "Robert Anthony De Niro Jr. born August 17, 1943 is an American actor, producer, and director. He is particularly known for his nine collaborations with filmmaker Martin Scorsese, and is the recipient of various accolades, including two Academy Awards, a Golden Globe Award, the Cecil B. DeMille Award, and a Screen Actors Guild Life Achievement Award. In 2009, De Niro received the Kennedy Center Honor, and received a Presidential Medal of Freedom from U.S. President Barack Obama in 2016.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/58/Robert_De_Niro_Cannes_2016.jpg/220px-Robert_De_Niro_Cannes_2016.jpg",
                },
                new Igralec
                {
                    Ime = "Zazie",
                    Priimek = "Beetz",
                    Biografija = "Zazie Olivia Beetz born June 1, 1991 is a German-born American actress. She stars in the FX comedy-drama series Atlanta (2016–present), for which she received a nomination for the Primetime Emmy Award for Outstanding Supporting Actress in a Comedy Series. She also appeared in the Netflix anthology series Easy (2016–19) and voices Amber Bennett in Amazon's animated superhero action series Invincible.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Zazie_Beetz_by_Gage_Skidmore_%28cropped%29.jpg/220px-Zazie_Beetz_by_Gage_Skidmore_%28cropped%29.jpg",
                },
                new Igralec
                {
                    Ime = "Matthew",
                    Priimek = "McConaughey",
                    Biografija = "Matthew David McConaughey born November 4, 1969 is an American actor. He had his breakout role with a supporting performance in the coming-of-age comedy Dazed and Confused (1993). After a number of supporting roles, his first success as a leading man came in the legal drama A Time to Kill (1996). His career progressed with lead roles in the science fiction film Contact (1997), the historical drama Amistad (1997), and the war film U-571 (2000).",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Matthew_McConaughey_2019_%2848648344772%29.jpg/220px-Matthew_McConaughey_2019_%2848648344772%29.jpg",
                },
                new Igralec
                {
                    Ime = "Jessica",
                    Priimek = "Chastain",
                    Biografija = "Jessica Michelle Chastain born March 24, 1977 is an American actress and film producer. Known primarily for starring in films with feminist themes, she has received various accolades, including an Academy Award and a Golden Globe Award. Time magazine named her one of the 100 most influential people in the world in 2012.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a5/SDCC_2015_-_Jessica_Chastain_%2819111308673%29_%28cropped%29.jpg/220px-SDCC_2015_-_Jessica_Chastain_%2819111308673%29_%28cropped%29.jpg",
                },
                new Igralec
                {
                    Ime = "Ryan",
                    Priimek = "Reynolds",
                    Biografija = "Ryan Rodney Reynolds born October 23, 1976 is a Canadian-American actor and producer. Throughout his 30-year career in film and television, he has received multiple accolades, including a Critics' Choice Movie Award, three People's Choice Awards, a Grammy and Golden Globe nomination, and a star on the Hollywood Walk of Fame. Led by his several appearances as Deadpool in Marvel films, he is one of the highest-grossing film actors of all time, with a worldwide box-office gross of over $5 billion worldwide.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/14/Deadpool_2_Japan_Premiere_Red_Carpet_Ryan_Reynolds_%28cropped%29.jpg/220px-Deadpool_2_Japan_Premiere_Red_Carpet_Ryan_Reynolds_%28cropped%29.jpg",
                },
                new Igralec
                {
                    Ime = "Jodie",
                    Priimek = "Comer",
                    Biografija = "Jodie Marie Comer born 11 March 1993 is an English actress. She is best known for her role as Oksana Astankova / Villanelle in the BBC America spy thriller Killing Eve (2018–2022), for which she received critical acclaim and won the Primetime Emmy Award for Outstanding Lead Actress in a Drama Series and the British Academy Television Award for Best Actress.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/11/Jodie_Comer_during_an_interview%2C_September_2021_%28cropped%29.png/220px-Jodie_Comer_during_an_interview%2C_September_2021_%28cropped%29.png",
                },
                new Igralec
                {
                    Ime = "Taika",
                    Priimek = "Waititi",
                    Biografija = "Taika David Cohen ONZM born 16 August 1975, known professionally as Taika Waititi, is a New Zealand filmmaker, actor and comedian. He is a recipient of an Academy Award, a BAFTA Award, and a Grammy Award, and has received two nominations at the Primetime Emmy Awards. His feature films Boy (2010) and Hunt for the Wilderpeople (2016) have each been the top-grossing New Zealand film.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/Taika_Waititi_by_Gage_Skidmore_2.jpg/220px-Taika_Waititi_by_Gage_Skidmore_2.jpg",
                },
                new Igralec
                {
                    Ime = "Daniel",
                    Priimek = "Craig",
                    Biografija = "Daniel Wroughton Craig CMG born 2 March 1968 is an English actor. He gained international fame playing the secret agent James Bond in the film series, beginning with Casino Royale (2006) and in four further instalments, up to No Time to Die (2021).",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Daniel_Craig_in_2021.jpg/220px-Daniel_Craig_in_2021.jpg",
                },
                new Igralec
                {
                    Ime = "Rami",
                    Priimek = "Malek",
                    Biografija = "Rami Said Malek born May 12, 1981 is an American actor. He is known for portraying computer hacker Elliot Alderson in the USA Network television series Mr. Robot (2015–2019), for which he received the Primetime Emmy Award for Outstanding Lead Actor in a Drama Series, and as Queen lead singer Freddie Mercury in the biopic Bohemian Rhapsody (2018), for which he won the Academy Award, Golden Globe Award, Screen Actors Guild Award, and British Academy Film Award for Best Actor.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8e/Rami_Malek_in_2015_%282%29_%28cropped%29.jpg/220px-Rami_Malek_in_2015_%282%29_%28cropped%29.jpg",
                },
                new Igralec
                {
                    Ime = "Tom",
                    Priimek = "Hanks",
                    Biografija = "Thomas Jeffrey Hanks born July 9, 1956 is an American actor and filmmaker. Known for both his comedic and dramatic roles, he is one of the most popular and recognizable film stars worldwide, and is regarded as an American cultural icon. Hanks's films have grossed more than $4.9 billion in North America and more than $9.96 billion worldwide, making him the fourth-highest-grossing actor in North America.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Tom_Hanks_TIFF_2019.jpg/220px-Tom_Hanks_TIFF_2019.jpg",
                },
                new Igralec
                {
                    Ime = "Robin",
                    Priimek = "Wright",
                    Biografija = "Robin Gayle Wright born April 8, 1966 is an American actress. She has won a Golden Globe Award and a Satellite Award, and has received eleven Emmy Award nominations for her work in television.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Robin_Wright_2009.jpg/220px-Robin_Wright_2009.jpg",
                },
                new Igralec
                {
                    Ime = "Gary",
                    Priimek = "Sinise",
                    Biografija = "Gary Alan Sinise born March 17, 1955 is an American actor, humanitarian, and musician. Among other awards, he has won a Primetime Emmy Award, a Golden Globe Award, a Tony Award, and four Screen Actors Guild Awards. He has also received a star on the Hollywood Walk of Fame, and was nominated for an Academy Award.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/90/Gary_Sinise_2011_%28cropped%29.jpg/220px-Gary_Sinise_2011_%28cropped%29.jpg",
                },
                new Igralec
                {
                    Ime = "Joseph",
                    Priimek = "Gordon-Levitt",
                    Biografija = "Joseph Leonard Gordon-Levitt born February 17, 1981 is an American actor and filmmaker. He has received various accolades, including nominations for the Golden Globe Award for Best Actor – Motion Picture Musical or Comedy for his leading performances in 500 Days of Summer (2009) and 50/50 (2011).",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/Joseph_Gordon-Levitt_TechCrunch_Disrupt_San_Francisco_2019_-_Day_1_%28cropped%29.jpeg/220px-Joseph_Gordon-Levitt_TechCrunch_Disrupt_San_Francisco_2019_-_Day_1_%28cropped%29.jpeg",
                },
                new Igralec
                {
                    Ime = "Elliot",
                    Priimek = "Page",
                    Biografija = "Elliot Page (formerly Ellen Page; born February 21, 1987) is a Canadian actor and producer. He has received various accolades, including an Oscar nomination, two BAFTA and Emmy nominations, and a Satellite Award.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/71/Elliot_Page_2021.png/220px-Elliot_Page_2021.png",
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