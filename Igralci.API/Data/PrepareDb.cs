using Igralci.API.Models;

namespace Igralci.API.Data;

public static class PrepareDb
{
    public static void InitializeDataSeed(IApplicationBuilder app)
    {
        using IServiceScope? serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<IgralciDbContext>());
    }

    private static void SeedData(IgralciDbContext database)
    {
        if (!database.Igralci.Any())
        {
            Console.WriteLine("[PrepareDb][{0}] Seeding data...", DateTime.Now);

            database.Igralci.AddRange(
                new Igralec
                {
                    Ime = "Robert",
                    Priimek = "Pattinson",
                    DatumRojstva = new DateTime(1986, 5, 13),
                    Biografija = "Pattinson, ki je bil rojen in vzgojen v Londonu, je s kariero pričel kot amaterski igralec v gledališču. Zatem je deloval tudi kot fotomodel, a s tem poslom je po komaj štirih letih prenehal. Svoj preboj je doživel z vlogo Cedrica Diggorya v filmu Harry Potter in ognjeni kelih, posnetem po istoimenskem romanu J.K. Rowling. Kasneje je dobil vlogo Edwarda Cullena v filmski seriji Somrak, posneti po romanih iz istoimenske knjižne serije Stephenie Meyer, s katero je postal prepoznaven po svetu in za katero je prejel mnogo nagrad. Leta 2010 je veliko pozornosti pritegnil tudi s filmom Ne pozabi me, leta 2011 pa s filmom Voda za slone, posnetem po istoimenski knjižni uspešnici, kjer je ob Reese Witherspoon zaigral glavno vlogo. Edwarda Cullena bo upodobil tudi v še prihajajočih nadaljevanjih serije Somrak, filmih Jutranja zarja - 1. del (2011) in Jutranja zarja - 2. del (2012), poleg tega pa bo leta 2012 izdal tudi film Cosmopolis.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Robert_Pattinson_Premiere_of_The_Lost_City_of_Z_at_Zoo_Palast_Berlinale_2017_02.jpg/800px-Robert_Pattinson_Premiere_of_The_Lost_City_of_Z_at_Zoo_Palast_Berlinale_2017_02.jpg",
                },
                new Igralec
                {
                    Ime = "Timothée",
                    Priimek = "Chalamet",
                    DatumRojstva = new DateTime(1995, 12, 27),
                    Biografija = "Chalamet se je rodil in odraščal v New Yorku, kariero pa je začel na odru in v televizijskih produkcijah ter leta 2012 nastopil v dramski seriji Domovina. Dve leti pozneje je debitiral v celovečercu v komični drami Men, Women & Children in nastopil v znanstvenofantastičnem filmu Christopherja Nolana Interstellar. Mednarodno pozornost je Chalamet pritegnil z glavno vlogo zaljubljenega najstnika v filmu Luce Guadagnina o odraščanju Pokliči me po svojem imenu (2017), ki mu je prinesla nominacijo za oskarja za najboljšega igralca. Sledili sta stranski vlogi v filmih Grete Gerwig Lady Bird (2017) in Little Women (2019), nato pa je prevzel glavni vlogi Nica Sheffa v drami Beautiful Boy (2018) in Paula Atreidesa v znanstvenofantastičnem filmu Denisa Villeneuva Dune (2021).",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Timoth%C3%A9e_Chalamet_2017_Berlinale.jpg/800px-Timoth%C3%A9e_Chalamet_2017_Berlinale.jpg",
                },
                new Igralec
                {
                    Ime = "Tom",
                    Priimek = "Holland",
                    DatumRojstva = new DateTime(1996, 6, 1),
                    Biografija = "Hollandova kariera se je začela pri devetih letih, ko se je vpisal v plesni tečaj, kjer ga je opazil koreograf in mu uredil avdicijo za vlogo v muzikalu Billy Elliot v londonskem gledališču Victoria Palace. Po dveh letih treninga je leta 2008 dobil stransko vlogo in še istega leta glavno vlogo, ki jo je igral do leta 2010. Holland je v filmu debitiral v drami o katastrofi Nemogoče (2012) v vlogi najstniškega turista, ujetega v cunamiju, za katero je prejel nagrado London Film Critics Circle za mladega britanskega igralca leta. Po tem se je Holland odločil, da se bo igralstvu posvetil za polni delovni čas, in tako je nastopil v filmu Kako živim zdaj (2013) ter igral zgodovinske osebnosti v filmu V osrčju morja (2015) in miniseriji Wolf Hall (2015).",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3c/Tom_Holland_by_Gage_Skidmore.jpg/800px-Tom_Holland_by_Gage_Skidmore.jpg",
                },
                new Igralec
                {
                    Ime = "Robert",
                    Priimek = "Downey",
                    DatumRojstva = new DateTime(1965, 4, 4),
                    Biografija = "Ameriški igralec in producent. Za njegovo kariero je značilen uspeh pri kritikih in gledalcih v mladosti, ki mu je sledilo obdobje zlorabe psihoaktivnih snovi in težav s pravom, nato pa je v nadaljevanju kariere ponovno dosegel komercialni uspeh. Leta 2008 je revija Time Downeyja uvrstila med 100 najvplivnejših ljudi na svetu, med letoma 2013 in 2015 pa ga je Forbes uvrstil na seznam najbolje plačanih igralcev v Hollywoodu.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Robert_Downey_Jr_2014_Comic_Con_%28cropped%29.jpg/800px-Robert_Downey_Jr_2014_Comic_Con_%28cropped%29.jpg",
                },
                new Igralec
                {
                    Ime = "Leonardo",
                    Priimek = "DiCaprio",
                    DatumRojstva = new DateTime(1974, 11, 11),
                    Biografija = "DiCaprio se je rodil v Los Angelesu in svojo kariero začel konec osemdesetih let prejšnjega stoletja z nastopanjem v televizijskih oglasih. V začetku devetdesetih let je imel ponavljajoče se vloge v različnih televizijskih oddajah, kot je na primer sitcom Parenthood, in svojo prvo večjo filmsko vlogo kot pisatelj Tobias Wolff v filmu This Boy's Life (1993). Pri 19 letih je prejel priznanje kritikov ter prvi nominaciji za oskarja in zlati globus za vlogo dečka z motnjo v razvoju v filmu What's Eating Gilbert Grape (1993). Mednarodno slavo je dosegel z romantičnima filmoma Romeo + Julija (1996) in Titanik (1997). Potem ko je slednji postal najbolj donosen film tistega časa, je za nekaj let zmanjšal svoj obseg dela. Da bi se znebil podobe romantičnega junaka, je DiCaprio iskal vloge v drugih žanrih, med drugim v kriminalnih dramah Ujemi me, če me moreš (2002) in Gangs of New York (2002); slednji je pomenil prvo od številnih uspešnih sodelovanj z režiserjem Martinom Scorsesejem.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/4/46/Leonardo_Dicaprio_Cannes_2019.jpg",
                },
                new Igralec
                {
                    Ime = "Ana",
                    Priimek = "de Armas",
                    DatumRojstva = new DateTime(1988, 4, 30),
                    Biografija = "Po selitvi v Los Angeles je de Armas odigrala angleško govoreče vloge v erotičnem trilerju Knock Knock (2015) in komično-kriminalnem filmu War Dogs (2016) ter stransko vlogo v športni biografiji Hands of Stone (2016). Zaslovela je z vlogo holografske projekcije umetne inteligence v znanstvenofantastičnem filmu Blade Runner 2049 (2017). Za vlogo medicinske sestre Marte Cabrere v skrivnostnem filmu Knives Out (2019) je bila de Armasova nominirana za zlati globus za najboljšo igralko v komediji ali muzikalu in prejela nagrado Saturn za najboljšo stransko igralko. Igrala je Bondovo dekle Palomo v filmu o Jamesu Bondu Ni časa za smrt (2021), v Netflixovi biografski drami Blonde (2022) pa naj bi upodobila Marilyn Monroe.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/e/e8/Ana_De_Armas_%28cropped%29.png",
                },
                new Igralec
                {
                    Ime = "Zendaya Maree",
                    Priimek = "Stoermer Coleman",
                    DatumRojstva = new DateTime(1996, 8, 1),
                    Biografija = "Svojo kariero je začela kot otroški model, ko je delala za Macy's, Mervyns in Old Navy. Bila je spremljevalna plesalka, nato pa je zaslovela z vlogo Rocky Blue v komediji Shake It Up (2010) na Disney Channelu, v kateri igrajo tudi Bella Thorne, Kenton Duty in Roshon Fegan. Zendaya je bila tekmovalka v šestnajsti sezoni tekmovalne serije Dancing with the Stars. Nato je producirala in igrala kot K. C. Cooper v sitcomu Disney Channel K. C. Undercover (2015) Filmski preboj ji je uspel leta 2017 z vlogo Michelle \"MJ\" Jones v filmu o superjunaku iz Marvelovega filmskega vesolja Spider-Man: Homecoming (2017) in kot Anne Wheeler v glasbeni drami The Greatest Showman (2017) ob igralcih, kot so Tom Holland, Hugh Jackman in Zac Efron. Poleg igranja, petja in plesa je tudi ambasadorka organizacije Convoy of Hope. Napisala je knjigo, lansirala svojo linijo oblačil (Daya by Zendaya) in dokazala, da je velik vzor mladim dekletom po vsem svetu.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/28/Zendaya_-_2019_by_Glenn_Francis.jpg/800px-Zendaya_-_2019_by_Glenn_Francis.jpg"
                },
                new Igralec
                {
                    Ime = "Natalie",
                    Priimek = "Portman",
                    DatumRojstva = new DateTime(1981, 6, 9),
                    Biografija = "Je edini otrok Avnerja Hershlaga, v Izraelu rojenega zdravnika, in Shelley Stevens, v ZDA rojene umetnice (iz Cincinnatija v Ohiu), ki je tudi Natalijina agentka. Njena starša sta aškenazijskega judovskega porekla. Natalijina družina se je iz Izraela preselila v Washington, D.C., ko je bila Natalie še zelo majhna. Po nekaj selitvah se je družina končno ustalila v New Yorku, kjer živi še danes. Maturirala je z odliko, njeni akademski dosežki pa so ji omogočili študij na univerzi Harvard. Pri 11 letih jo je v piceriji odkril agent. Nagovarjal jo je k manekenski karieri, vendar se je odločila, da se bo raje posvetila igralski karieri. Nastopila je v številnih nastopih v živo, v filmu Léon pa je debitirala v močni filmski vlogi: (1994) (tudi \"Léon\"). Po tej vlogi je Natalie dobila vloge v filmih, kot so Vročina (1995), Lepa dekleta (1996) in Mars napada! (1996).",
                    Fotografija = "https://media.vanityfair.com/photos/5e4563b4609b5f0008cf47bc/master/pass/GettyImages-1205162493.jpg",
                },
                new Igralec
                {
                    Ime = "Jennifer",
                    Priimek = "Lawrence",
                    DatumRojstva = new DateTime(1990, 8, 15),
                    Biografija = "V otroštvu je Lawrence nastopal v cerkvenih igrah in šolskih muzikalih. Pri 14 letih jo je med počitnicami v New Yorku z družino opazil iskalec talentov. Preselila se je v Los Angeles in začela igralsko kariero z gostujočimi vlogami na televiziji. Njena prva večja vloga je bila glavna igralka v komediji The Bill Engvall Show (2007-2009). Na filmu je debitirala v stranski vlogi v drami Garden Party (2008), preboj pa je doživela z vlogo revne najstnice v neodvisni skrivnostni drami Winter's Bone (2010). Lawrenceova kariera je napredovala z glavnima vlogama mutantke Mystique v seriji filmov Možje X (2011-2019) in Katniss Everdeen v seriji filmov Igre lakote (2012-2015). S slednjo je postala najdonosnejša akcijska junakinja vseh časov.",
                    Fotografija = "https://www.pinkvilla.com/files/styles/amp_metadata_content_image/public/jennifer_lost_tooth.jpg",
                },
                new Igralec
                {
                    Ime = "Anne",
                    Priimek = "Hathaway",
                    DatumRojstva = new DateTime(1982, 11, 12),
                    Biografija = "Hathawayeva je končala srednjo šolo Millburn High School v New Jerseyju, kjer je igrala v več predstavah. Kot najstnica je igrala v televizijski seriji Get Real (1999-2000), preboj pa ji je uspel z vlogo glavne junakinje v njenem filmskem prvencu, Disneyjevi komediji The Princess Diaries (2001). Po nastopu v vrsti neuspešnih družinskih filmov je Hathawayeva prešla k vlogam za odrasle z dramama Havoc in Brokeback Mountain iz leta 2005. Komična drama Hudič nosi Prado (The Devil Wears Prada, 2006), v kateri je igrala pomočnico urednice modne revije, je bila do takrat njen največji komercialni uspeh. V drami Rachel se poroči (Rachel Getting Married, 2008) je igrala ozdravljeno odvisnico z duševno boleznijo, za katero je bila nominirana za oskarja za najboljšo igralko.",
                    Fotografija = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cd/Anne_Hathaway_at_MIFF_%28cropped%29.jpg/800px-Anne_Hathaway_at_MIFF_%28cropped%29.jpg",
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