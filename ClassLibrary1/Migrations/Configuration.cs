namespace BioscoopB3Web.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BioscoopB3Web.Domain.Concrete;
    using Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<BioscoopB3Web.Domain.Concrete.BioscoopModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BioscoopB3Web.Domain.Concrete.BioscoopModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.HallLayouts.AddOrUpdate(
                HL => HL.HallLayoutID,
                new HallLayout()
                {
                    HallLayoutID = 1,
                    SeatsPerRow = 10,
                    Rows = 10
                },
                new HallLayout()
                {
                    HallLayoutID = 2,
                    SeatsPerRow = 15,
                    Rows = 5
                },
                new HallLayout()
                {
                    HallLayoutID = 3,
                    SeatsPerRow = 20,
                    Rows = 10
                });

            context.Movies.AddOrUpdate(
                M => M.MovieID,
                new Movie()
                {
                    MovieID = 1,
                    Title = "Deadpool",
                    Description = "Deadpool is een Amerikaanse komische superheldenfilm uit 2016, gebaseerd op het Marvel Comics-personage Deadpool. Het is de achtste film in de X-Men filmserie. De hoofdrollen worden vertolkt door Ryan Reynolds, Morena Baccarin, Ed Skrein, T.J. Miller en Gina Carano. De film ging op 8 februari 2016 in première",
                    Length = 118,
                    Language = "Nederlands",
                    Subtitles = true,
                    Genre = "Action, Comedy",
                    Age = "12",
                    ThreeD = false,
                    RunTime = new DateTime(2017, 8, 20),
                    Director = "Steven Spielberg",
                    Actor = "Jason Stattham, Sean Vissers",
                    Imdb = "http://www.imdb.com/title/tt1431045/",
                    Trailer = "https://www.youtube.com/watch?v=I4tFNfROlqk&t=74s",
                    Site = "http://www.foxmovies.com/movies/deadpool",
                    ImgUrl = "http://t1.gstatic.com/images?q=tbn:ANd9GcR-fLY3Z9Vn28UB-A3X_w0vjmkHcXG89HWwul5w6-sg3IonPXA_"
                },
                new Movie()
                {
                    MovieID = 2,
                    Title = "Lord of the rings",
                    Description = "Een Ring wordt weer gevonden in het land van Midden-Aarde(Middle-Earth), Gandalf, de tovenaar, komt bij een van zijn bezoeken aan de Hobbits, halflingen, erachter dat het de Ene Ring is, gesmeed door de zwarte heerser zelf, Sauron. Gandalf raadt Frodo aan om het in de vulkanen van Mordor te gooien, in dezelfde vuren waar hij is gesmeed. Het enige probleem is…in Mordor woont Sauron, ook al niet in zijn oorspronkelijke vorm, blijft hij machtig, mededankzij zijn lakeien de Nazgúl.",
                    Length = 160,
                    Language = "Engels",
                    Subtitles = true,
                    Genre = "Adventure, Sci-Fi",
                    Age = "12",
                    ThreeD = false,
                    RunTime = new DateTime(2017, 6, 15),
                    Director = "Peter Jackson",
                    Actor = "Elijah Wood, Ian McKellen, Orlando Bloom",
                    Imdb = "http://www.imdb.com/title/tt0120737/",
                    Trailer = "https://www.youtube.com/watch?v=V75dMMIW2B4",
                    Site = "http://www.theonering.com/",
                    ImgUrl = "http://static.rogerebert.com/uploads/movie/movie_poster/lord-of-the-rings-the-fellowship-of-the-ring-2001/large_9HG6pINW1KoFTAKY3LdybkoOKAm.jpg"
                },
                new Movie()
                {
                    MovieID = 3,
                    Title = "Star wars: Rogue One",
                    Description = "Rogue One: A Star Wars Story[4], of kortweg Rogue One, is een Amerikaanse sciencefictionfilm uit 2016 en het eerste deel uit de anthologyreeks van de succesvolle filmfranchise Star Wars. De film wordt geregisseerd door Gareth Edwards en geproduceerd door Lucasfilm en Walt Disney Pictures. Het scenario van de film is van de hand van Gary Whitta en Chris Weitz, gebaseerd op een idee van John Knoll. Felicity Jones speelt de hoofdrol in de film.",
                    Length = 163,
                    Language = "Nederlands",
                    Subtitles = true,
                    Genre = "Sci-Fi",
                    Age = "18",
                    ThreeD = false,
                    RunTime = new DateTime(2017, 7, 25),
                    Director = "George Lucas",
                    Actor = "Mark Hamill, Harrison Ford, Carrie Fisher",
                    Imdb = "http://www.imdb.com/title/tt0076759/",
                    Trailer = "https://www.youtube.com/watch?v=1g3_CFmnU7k",
                    Site = "",
                    ImgUrl = "https://lumiere-a.akamaihd.net/v1/images/rogueone_onesheeta_1000_309ed8f6.jpeg?region=0%2C0%2C1000%2C1481&width=480"
                },
                new Movie()
                {
                    MovieID = 4,
                    Title = "Star Trek: The Motion Picture",
                    Description = "In 2273 wordt het Klingonrijk binnengevallen door een buitenaardse macht, verhuld in een gigantische energiewolk met een diameter van meer dan 10 miljard kilometer. Deze vernietigt drie Klingonschepen en Epsilon 9, een buitenpost van de Federatie. De wolk lijkt op weg naar de Aarde te zijn. De USS Enterprise NCC-1701 wordt er op uitgestuurd om het fenomeen te onderzoeken.",
                    Length = 135,
                    Language = "Engels",
                    Subtitles = true,
                    Genre = "Sci-Fi",
                    Age = "16",
                    ThreeD = false,
                    RunTime = new DateTime(2017, 9, 23),
                    Director = "Robert Wise",
                    Actor = "William Shatner, Leonard Nimoy, DeForest Kelley",
                    Imdb = "http://www.imdb.com/title/tt0079945/",
                    Trailer = "https://www.youtube.com/watch?v=ZLlV_JVtO5c",
                    Site = "",
                    ImgUrl = "http://worldcinemaparadise.com/wp/wp-content/uploads/2015/04/STTMP.jpg"
                },
                new Movie()
                {
                    MovieID = 5,
                    Title = "Logan",
                    Description = "In de nabije toekomst, een vermoeide Logan zorgt voor een noodlijdende Professor X in een schuilplaats aan de Mexicaanse grens. Maar Logan's pogingen om te verbergen voor de wereld en zijn erfenis zijn up-eindigde toen een jonge mutant komt, door duistere krachten worden nagestreefd.",
                    Length = 200,
                    Language = "Engels",
                    Subtitles = true,
                    Genre = "Sci-Fi, Action",
                    Age = "18",
                    ThreeD = true,
                    RunTime = new DateTime(2017, 9, 23),
                    Director = "Mathijs Kors",
                    Actor = "Mathijs Kors",
                    Imdb = "http://www.imdb.com/title/tt3315342/?ref_=fn_al_tt_1",
                    Trailer = "https://www.youtube.com/watch?v=DekuSxJgpbY",
                    Site = "",
                    ImgUrl = "http://cdn2-www.superherohype.com/assets/uploads/gallery/untitled-wolverine-sequel/cuaiczwueaaid_w-jpg-large.jpg"
                },
                new Movie()
                {
                    MovieID = 6,
                    Title = "The Shawshank Redemption",
                    Description = "In de nabije toekomst, een vermoeide Logan zorgt voor een noodlijdende Professor X in een schuilplaats aan de Mexicaanse grens. Maar Logan's pogingen om te verbergen voor de wereld en zijn erfenis zijn up-eindigde toen een jonge mutant komt, door duistere krachten worden nagestreefd.",
                    Length = 120,
                    Language = "Engels",
                    Subtitles = true,
                    Genre = "Drama",
                    Age = "18",
                    ThreeD = false,
                    RunTime = new DateTime(2017, 9, 23),
                    Director = "Stephen King",
                    Actor = "Tim Robbins, Morgan Freeman, Bob Gunton",
                    Imdb = "http://www.imdb.com/title/tt0111161/?pf_rd_m=A2FGELUUNOQJNL&pf_rd_p=2398042102&pf_rd_r=0F1RE99KZV45YYAYDWWT&pf_rd_s=center-1&pf_rd_t=15506&pf_rd_i=top&ref_=chttp_tt_1",
                    Trailer = "https://www.youtube.com/watch?v=6hB3S9bIaco",
                    Site = "",
                    ImgUrl = "http://thegalileo.co.za/wp-content/uploads/2015/09/9O7gLzmreU0nGkIB6K3BsJbzvNv.jpg"
                });

                context.Halls.AddOrUpdate(h => h.HallID,
                    new Hall()
                    {
                        HallID = 1,
                        Capacity = 75,
                        HallLayoutID = 1                     
                    },
                    new Hall()
                    {
                        HallID = 2,
                        Capacity = 75,
                        HallLayoutID = 2
                    },
                    new Hall()
                    {
                        HallID = 3,
                        Capacity = 75,
                        HallLayoutID = 3
                    }
                );

            context.Surveys.AddOrUpdate(s => s.SurveyID,
                new Survey()
                {
                    SurveyID = 1,
                    OpenQ = "Test",
                    OpenQIsDeleted = false,
                    ScoreQ = 3,
                    MultipleChoiceQ = "Kan beter"
                }
                );

                //context.HallMovies.AddOrUpdate(h => h.HallMovieID,
                //    new HallMovie()
                //    {
                //        MovieID = 1,
                //        HallID = 1,
                //        DateTime = new DateTime(2017, 3, 21, 18, 30, 0),
                //        LadiesNight = true
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 2,
                //        HallID = 2,
                //        DateTime = new DateTime(2017, 3, 22, 18, 0, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 3,
                //        HallID = 3,
                //        DateTime = new DateTime(2017, 3, 22, 20, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 4,
                //        HallID = 2,
                //        DateTime = new DateTime(2017, 3, 20, 20, 00, 0),
                //        LadiesNight = true
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 1,
                //        HallID = 1,
                //        DateTime = new DateTime(2017, 3, 26, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 3,
                //        HallID = 2,
                //        DateTime = new DateTime(2017, 3, 27, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 2,
                //        HallID = 1,
                //        DateTime = new DateTime(2017, 3, 28, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 1,
                //        HallID = 3,
                //        DateTime = new DateTime(2017, 3, 24, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 4,
                //        HallID = 1,
                //        DateTime = new DateTime(2017, 3, 22, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 3,
                //        HallID = 2,
                //        DateTime = new DateTime(2017, 3, 26, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 2,
                //        HallID = 3,
                //        DateTime = new DateTime(2017, 3, 17, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 1,
                //        HallID = 1,
                //        DateTime = new DateTime(2017, 3, 10, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 2,
                //        HallID = 2,
                //        DateTime = new DateTime(2017, 3, 11, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 1,
                //        HallID = 3,
                //        DateTime = new DateTime(2017, 3, 12, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 4,
                //        HallID = 1,
                //        DateTime = new DateTime(2017, 3, 9, 21, 30, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 5,
                //        HallID = 2,
                //        DateTime = new DateTime(2017, 3, 9, 17, 00, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 6,
                //        HallID = 2,
                //        DateTime = new DateTime(2017, 3, 9, 16, 45, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 1,
                //        HallID = 2,
                //        DateTime = new DateTime(2017, 3, 10, 12, 00, 0),
                //        LadiesNight = false
                //    },
                //    new HallMovie()
                //    {
                //        MovieID = 1,
                //        HallID = 2,
                //        DateTime = new DateTime(2017, 3, 14, 15, 00, 0),
                //        LadiesNight = false
                //    }
                //);

            context.Accounts.AddOrUpdate(a => a.Email,
                new Account()
                {
                    Email = "a@a.nl",
                    Name = "a",
                    WantsNewsletter = false,
                    Password = "a",
                    AccountType = "BackOffice"
                },
                new Account()
                {
                    Email = "b@b.nl",
                    Name = "b",
                    WantsNewsletter = false,
                    Password = "b",
                    AccountType = "Cashier"
                },
                new Account()
                {
                    Email = "c@c.nl",
                    Name = "c",
                    WantsNewsletter = false,
                    Password = "c",
                    AccountType = "Manager"
                },
                new Account()
                {
                    Email = "d@d.nl",
                    Name = "d",
                    WantsNewsletter = false,
                    Password = "d",
                    AccountType = "SubscriptionHolder",
                    Street = "Sesamstraat",
                    StreetNumber = 6,
                    City = "Utopia"
                },
                new Account()
                {
                    Email = "billybouman@ziggo.nl",
                    Name = "Billy",
                    LastName = "Bouman",
                    WantsNewsletter = true,
                    AccountType = "NewsMailAccount",
                    Gender = "Male"
                },
                new Account()
                {
                    Email = "billybouman@gmail.com",
                    Name = "Billy",
                    LastName = "Bouman",
                    WantsNewsletter = true,
                    AccountType = "NewsMailAccount",
                    Gender = "Female",
                });
        }
        

    }
}
